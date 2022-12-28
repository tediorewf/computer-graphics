#include "Camera.h"
#include "Player.h"
#include "Vertex.h"
#include "obj-parser.h"

#include <GL/glew.h>
#include <SFML/Audio.hpp>
#include <SFML/Graphics.hpp>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SOIL/SOIL.h>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glm/mat4x4.hpp>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>

#include <iostream>
#include <random>

GLuint Program;

GLint Attrib_vertex_position;
GLuint Attrib_vertex_texture_coordinate;
GLint Attrib_vertex_normal;

GLuint VBO;
const GLuint NUM_TEXTURES = 6;
GLuint textures[NUM_TEXTURES];

const char *VertexShaderSource = R"(
    #version 330 core

    in vec3 position;
    in vec2 texcoord;
    in vec3 normal;

    out vec3 vs_position;
    out vec2 vs_texcoord;
    out vec3 vs_normal;

    uniform mat4 model;
    uniform mat4 view;
    uniform mat4 projection;

    void main() {
        vs_position = vec4(model * vec4(position, 1.0f)).xyz;
        vs_texcoord = vec2(texcoord.x, texcoord.y);
        vs_normal = normal;

        gl_Position = projection * view * model * vec4(position, 1.0f);
    }
)";

// https://learnopengl.com/Lighting/Light-casters
// http://steps3d.narod.ru/tutorials/lighting-tutorial.html
const char *FragmentShaderSource = R"(
    #version 330 core

    struct DirLight {
        vec3 direction;
    };

    struct SpotLight {
        vec3 position;
        vec3 direction;

        float innerCone;
        float outerCone;
    };

    in vec3 vs_position;
    in vec2 vs_texcoord;
    in vec3 vs_normal;   

    uniform vec3 view_position;

    uniform sampler2D texture;

    uniform DirLight dirLight;
    uniform SpotLight spotLight;

    out vec4 color;

    vec4 shadePhong(vec3 light_direction, vec3 view_direction, float intensivity)
    {
        vec4 textureColor = texture(texture, vs_texcoord);
        vec3 normal = normalize(vs_normal);
        vec3 lightDir = normalize(light_direction);
        vec3 viewDir = normalize(view_direction);
        vec3 reflectedViewDir = reflect(-viewDir, normal);
        vec4 diff = textureColor * max(dot(normal, lightDir), 0.0f);
        vec4 spec = textureColor * pow(max(dot(lightDir, reflectedViewDir), 0.0f), 8.0f);
        return (diff + spec) * intensivity;
    }
   
    void main() {
        vec3 dir_light_direction = dirLight.direction;
        vec3 spot_light_direction = spotLight.position - vs_position;

        vec3 view_direction = view_position - vs_position;
        
        float dir_light_intensivity = 0.55f;

        float theta = dot(normalize(spot_light_direction), normalize(-spotLight.direction));
        float spot_light_intensivity = clamp((theta - spotLight.outerCone) / (spotLight.innerCone - spotLight.outerCone), 0.0f, 1.0f);

        color = texture(texture, vs_texcoord);
        color += shadePhong(dir_light_direction, view_direction, dir_light_intensivity);
        color += shadePhong(spot_light_direction, view_direction, spot_light_intensivity);
    }
)";

void checkOpenGLerror() {
  GLenum err;
  while ((err = glGetError()) != GL_NO_ERROR) {
    std::cout << "GLerror Log: " << err << std::endl;
  }
}

// Танк
auto tank_mesh = parse_obj("Models/Tank.obj");
// Поле
auto field_mesh = parse_obj("Models/Field.obj");
// Бочка
auto barrel_mesh = parse_obj("Models/Barrel.obj");
// Камень 1
auto stone_mesh = parse_obj("Models/Stone-1.obj");
// Новогодняя ёлка
auto christmas_tree_mesh = parse_obj("Models/ChristmasTree.obj");
// Дерево
auto tree_mesh = parse_obj("Models/Tree.obj");

void InitVBO() {
  auto scene = std::vector<Vertex>();
  const std::size_t sceneSize = tank_mesh.size();
  scene.reserve(sceneSize);
  // Загружаем танк
  scene.insert(scene.end(), tank_mesh.begin(), tank_mesh.end());
  // Загружаем поле
  scene.insert(scene.end(), field_mesh.begin(), field_mesh.end());
  // Загружаем бочку
  scene.insert(scene.end(), barrel_mesh.begin(), barrel_mesh.end());
  // Загружаем камень
  scene.insert(scene.end(), stone_mesh.begin(), stone_mesh.end());
  // Загружаем новогоднюю ёлку
  scene.insert(scene.end(), christmas_tree_mesh.begin(),
               christmas_tree_mesh.end());
  // Загружаем дерево
  scene.insert(scene.end(), tree_mesh.begin(), tree_mesh.end());

  glGenBuffers(1, &VBO);
  glBindBuffer(GL_ARRAY_BUFFER, VBO);
  glBufferData(GL_ARRAY_BUFFER, sizeof(Vertex) * scene.size(), scene.data(),
               GL_STATIC_DRAW);
  checkOpenGLerror();
}

void ShaderLog(unsigned int shader) {
  int infologLen = 0;
  glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
  if (infologLen > 1) {
    int charsWritten = 0;
    std::vector<char> infoLog(infologLen);
    glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
    std::cout << "InfoLog: " << infoLog.data() << std::endl;
  }
}

void InitShader() {
  GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
  glShaderSource(vShader, 1, &VertexShaderSource, NULL);
  glCompileShader(vShader);
  std::cout << "vertex shader \n";
  ShaderLog(vShader);

  GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
  glShaderSource(fShader, 1, &FragmentShaderSource, NULL);
  glCompileShader(fShader);
  std::cout << "fragment shader \n";
  ShaderLog(fShader);

  Program = glCreateProgram();

  glAttachShader(Program, vShader);
  glAttachShader(Program, fShader);

  glLinkProgram(Program);
  int link_ok;
  glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
  if (!link_ok) {
    std::cout << "error attach shaders \n";
    return;
  }

  const char *attr_name_position = "position";
  Attrib_vertex_position = glGetAttribLocation(Program, attr_name_position);
  if (Attrib_vertex_position == -1) {
    std::cout << "could not bind attrib " << attr_name_position << std::endl;
    return;
  }

  const char *attr_name_texture_coordinate = "texcoord";
  Attrib_vertex_texture_coordinate =
      glGetAttribLocation(Program, attr_name_texture_coordinate);
  if (Attrib_vertex_texture_coordinate == -1) {
    std::cout << "could not bind attrib " << attr_name_texture_coordinate
              << std::endl;
    return;
  }

  const char *attr_name_normal = "normal";
  Attrib_vertex_normal = glGetAttribLocation(Program, attr_name_normal);
  if (Attrib_vertex_position == -1) {
    std::cout << "could not bind attrib " << attr_name_normal << std::endl;
    return;
  }

  checkOpenGLerror();
}

void _load_texture(const char *filename, GLuint unit, GLuint &texture) {
  int image_width, image_height;
  unsigned char *image =
      SOIL_load_image(filename, &image_width, &image_height, 0, SOIL_LOAD_RGBA);
  glActiveTexture(GL_TEXTURE0 + unit);
  glGenTextures(1, &texture);
  glBindTexture(GL_TEXTURE_2D, texture);

  if (image) {
    glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, image_width, image_height, 0,
                 GL_RGBA, GL_UNSIGNED_BYTE, image);
    glGenerateMipmap(GL_TEXTURE_2D);
  } else {
    std::cout << "could not load texture " << filename << std::endl;
    return;
  }

  glActiveTexture(0);
  glBindTexture(GL_TEXTURE_2D, 0);
  SOIL_free_image_data(image);
}

void _loadTextures(const std::vector<const char *> &imageNames) {
  for (GLuint unit = 0; unit < imageNames.size(); unit += 1) {
    _load_texture(imageNames[unit], unit, textures[unit]);
  }
}

void InitTextures() {
  _loadTextures(std::vector<const char *>{
      "Textures/Tank.png", "Textures/Field.png", "Textures/Barrel.png",
      "Textures/Stone-1.png", "Textures/ChristmasTree.png",
      "Textures/Tree.png"});
}

GLuint windowWidth = 1600, windowHeight = 1600;

auto player = Player(glm::vec3(0.0f, 0.0f, 0.0f), glm::vec3(0.0f, 5.0f, 0.0f),
                     glm::vec3(0.0f, 4.0f, 2.0f), 10.0f, 1.0f, 1.0f);
GLfloat pitch = 5.0f;
GLfloat distanceToPlayer = 8.0f;
auto worldUp = glm::vec3(0.0f, 1.0f, 0.0f);
GLfloat angleAroundPlayer = 0.0f;
GLfloat angleAroundPlayerStep = 1.0;
auto camera =
    Camera(player, pitch, distanceToPlayer, worldUp, angleAroundPlayer);

GLfloat zoomStep = 1.0;
GLfloat pitchStep = 1.0;

GLfloat directionLightX = 1.0f;
GLfloat directionLightY = 1.0f;
GLfloat directionLightZ = 1.0f;

std::random_device rd;
std::mt19937 mt(rd());
std::uniform_real_distribution<GLfloat> dist(-15.0f, 15.0f);

auto enemyTranslation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto barrel1Translation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto stone1Translation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto barrel2Translation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto stone2Translation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto christmasTreeTranslation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto tree1Translation = glm::vec3(dist(mt), 0.0f, dist(mt));
auto tree2Translation = glm::vec3(dist(mt), 0.0f, dist(mt));

void drawMesh(GLuint mode, GLuint unit, GLuint first, GLsizei count,
              glm::mat4 model) {
  glActiveTexture(GL_TEXTURE0 + unit);
  glBindTexture(GL_TEXTURE_2D, textures[unit]);
  glUniform1i(glGetUniformLocation(Program, "texture"), unit);

  glUniformMatrix4fv(glGetUniformLocation(Program, "model"), 1, GL_FALSE,
                     glm::value_ptr(model));
  glDrawArrays(mode, first, count);

  glActiveTexture(0);
  glBindTexture(GL_TEXTURE_2D, 0);
}

void Draw() {
  glUseProgram(Program);

  glEnableVertexAttribArray(Attrib_vertex_position);
  glEnableVertexAttribArray(Attrib_vertex_texture_coordinate);
  glEnableVertexAttribArray(Attrib_vertex_normal);

  glBindBuffer(GL_ARRAY_BUFFER, VBO);

  glVertexAttribPointer(Attrib_vertex_position, 3, GL_FLOAT, GL_FALSE,
                        sizeof(Vertex), (GLvoid *)offsetof(Vertex, position));
  glVertexAttribPointer(Attrib_vertex_texture_coordinate, 2, GL_FLOAT, GL_FALSE,
                        sizeof(Vertex), (GLvoid *)offsetof(Vertex, texcoord));
  glVertexAttribPointer(Attrib_vertex_normal, 3, GL_FLOAT, GL_FALSE,
                        sizeof(Vertex), (GLvoid *)offsetof(Vertex, normal));

  glBindBuffer(GL_ARRAY_BUFFER, 0);

  GLfloat field_of_view = 90;
  GLfloat near_plane = 0.01f;
  GLfloat far_plane = 10000.0f;
  glm::mat4 projection(1.0f);
  projection = glm::perspective(
      glm::radians(field_of_view),
      static_cast<GLfloat>(windowWidth) / windowHeight, near_plane, far_plane);

  glUniformMatrix4fv(glGetUniformLocation(Program, "view"), 1, GL_FALSE,
                     glm::value_ptr(camera.getViewMatrix()));
  glUniformMatrix4fv(glGetUniformLocation(Program, "projection"), 1, GL_FALSE,
                     glm::value_ptr(projection));

  glUniform3f(glGetUniformLocation(Program, "view_position"),
              camera.getPosition().x, camera.getPosition().y,
              camera.getPosition().z);

  glUniform3f(glGetUniformLocation(Program, "dirLight.direction"),
              directionLightX, directionLightY, directionLightZ);

  auto player = camera.getPlayer();
  auto playerPosition = player.getPosition();
  auto spotLightPosition = player.getSpotLightPosition();
  auto spotLightDirection = player.getSpotLightDirection();
  glUniform3f(glGetUniformLocation(Program, "spotLight.position"),
              spotLightPosition.x, spotLightPosition.y, spotLightPosition.z);
  glUniform3f(glGetUniformLocation(Program, "spotLight.direction"),
              spotLightDirection.x, spotLightDirection.y, spotLightDirection.z);
  glUniform1f(glGetUniformLocation(Program, "spotLight.innerCone"),
              cos(glm::radians(20.0f)));
  glUniform1f(glGetUniformLocation(Program, "spotLight.outerCone"),
              cos(glm::radians(25.0f)));

  glm::mat4 modelPlayer(1.0f);
  modelPlayer = glm::translate(modelPlayer, playerPosition);
  modelPlayer = glm::rotate(modelPlayer, glm::radians(player.getRotationY()),
                            glm::vec3(0.0f, 1.0f, 0.0f));
  modelPlayer = glm::rotate(modelPlayer, glm::radians(90.0f),
                            glm::vec3(0.0f, 1.0f, 0.0f));
  const GLuint playerFirst = 0;
  drawMesh(GL_TRIANGLES, 0, playerFirst, tank_mesh.size(), modelPlayer);

  glm::mat4 enemyModel(1.0f);
  enemyModel = glm::translate(enemyModel, enemyTranslation);
  enemyModel =
      glm::rotate(enemyModel, glm::radians(45.0f), glm::vec3(0.0f, 1.0f, 0.0f));
  const GLuint enemyFirst = 0;
  drawMesh(GL_TRIANGLES, 0, enemyFirst, tank_mesh.size(), enemyModel);

  glm::mat4 modelField(1.0f);
  const GLuint fieldFirst = tank_mesh.size();
  drawMesh(GL_TRIANGLES, 1, fieldFirst, field_mesh.size(), modelField);

  glm::mat4 barrel1Model(1.0f);
  barrel1Model = glm::translate(barrel1Model, barrel1Translation);
  const GLuint barrel1First = tank_mesh.size() + field_mesh.size();
  drawMesh(GL_TRIANGLES, 2, barrel1First, barrel_mesh.size(), barrel1Model);

  glm::mat4 barrel2Model(1.0f);
  barrel2Model = glm::translate(barrel2Model, barrel2Translation);
  const GLuint barrel2First = tank_mesh.size() + field_mesh.size();
  drawMesh(GL_TRIANGLES, 2, barrel2First, barrel_mesh.size(), barrel2Model);

  glm::mat4 stone1Model(1.0f);
  stone1Model = glm::translate(stone1Model, stone1Translation);
  const GLuint stone1First =
      tank_mesh.size() + field_mesh.size() + barrel_mesh.size();
  drawMesh(GL_TRIANGLES, 3, stone1First, stone_mesh.size(), stone1Model);

  glm::mat4 stone2Model(1.0f);
  stone2Model = glm::translate(stone2Model, stone2Translation);
  const GLuint stone2First =
      tank_mesh.size() + field_mesh.size() + barrel_mesh.size();
  drawMesh(GL_TRIANGLES, 3, stone2First, stone_mesh.size(), stone2Model);

  glm::mat4 christmasTreeModel(1.0f);
  christmasTreeModel =
      glm::translate(christmasTreeModel, christmasTreeTranslation);
  const GLuint christmasTreeFirst = tank_mesh.size() + field_mesh.size() +
                                    barrel_mesh.size() + stone_mesh.size();
  drawMesh(GL_TRIANGLES, 4, christmasTreeFirst, christmas_tree_mesh.size(),
           christmasTreeModel);

  glm::mat4 tree1Model(1.0f);
  tree1Model = glm::translate(tree1Model, tree1Translation);
  const GLuint tree1First = tank_mesh.size() + field_mesh.size() +
                            barrel_mesh.size() + stone_mesh.size() +
                            christmas_tree_mesh.size();
  drawMesh(GL_TRIANGLES, 5, tree1First, tree_mesh.size(), tree1Model);

  glm::mat4 tree2Model(1.0f);
  tree2Model = glm::translate(tree2Model, tree2Translation);
  const GLuint tree2First = tank_mesh.size() + field_mesh.size() +
                            barrel_mesh.size() + stone_mesh.size() +
                            christmas_tree_mesh.size();
  drawMesh(GL_TRIANGLES, 5, tree2First, tree_mesh.size(), tree2Model);

  glDisableVertexAttribArray(Attrib_vertex_position);
  glDisableVertexAttribArray(Attrib_vertex_texture_coordinate);

  glUseProgram(0);

  checkOpenGLerror();
}

void InitOptions() {
  glEnable(GL_DEPTH_TEST);
  glEnable(GL_CULL_FACE);
  glCullFace(GL_BACK);
  glFrontFace(GL_CCW);
  glEnable(GL_BLEND);
  glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
  glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
}

void Init() {
  InitOptions();
  InitShader();
  InitTextures();
  InitVBO();
}

void ReleaseVBO() {
  glBindBuffer(GL_ARRAY_BUFFER, 0);
  glDeleteBuffers(1, &VBO);
}

void ReleaseShader() {
  glUseProgram(0);
  glDeleteProgram(Program);
}

void Release() {
  ReleaseShader();
  ReleaseVBO();
}

int main() {
  sf::Window window(sf::VideoMode(windowWidth, windowHeight), "TankWorld",
                    sf::Style::Default, sf::ContextSettings(24));
  window.setVerticalSyncEnabled(true);
  window.setActive(true);

  glewInit();
  Init();
  auto clock = sf::Clock();
  auto elapsed = clock.getElapsedTime();
  GLfloat previousFrameRenderTime = elapsed.asMilliseconds();
  GLfloat framesRenderTimeDelta = previousFrameRenderTime;

  while (window.isOpen()) {
    sf::Event event;
    while (window.pollEvent(event)) {
      if (event.type == sf::Event::Closed) {
        window.close();
      } else if (event.type == sf::Event::Resized) {
        glViewport(0, 0, event.size.width, event.size.height);
        windowWidth = event.size.width;
        windowHeight = event.size.height;
      } else if (event.type == sf::Event::MouseWheelScrolled) {
        if (event.mouseWheelScroll.wheel == sf::Mouse::VerticalWheel) {
          if (event.mouseWheelScroll.delta < 0) {
            distanceToPlayer += zoomStep;
            camera.setDistanceToPlayer(distanceToPlayer);
          } else {
            distanceToPlayer -= zoomStep;
            camera.setDistanceToPlayer(distanceToPlayer);
          }
        } else if (event.mouseWheelScroll.wheel == sf::Mouse::HorizontalWheel) {
          if (event.mouseWheelScroll.delta < 0) {
            angleAroundPlayer += angleAroundPlayerStep;
            camera.setAngleAroundPlayer(angleAroundPlayer);
          } else {
            angleAroundPlayer -= angleAroundPlayerStep;
            camera.setAngleAroundPlayer(angleAroundPlayer);
          }
        }
        camera.updateVectors();
      } else if (event.type == sf::Event::KeyPressed) {
        if (event.key.code == sf::Keyboard::Up) {
          pitch += pitchStep;
          camera.setPitch(pitch);
          camera.updateVectors();
        } else if (event.key.code == sf::Keyboard::Down) {
          pitch -= pitchStep;
          camera.setPitch(pitch);
          camera.updateVectors();
        } else {
          camera.move(event, framesRenderTimeDelta);
        }
      }
    }
    glClearColor(0.1f, 0.6f, 0.2f, 1.f);
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    Draw();
    window.display();

    elapsed = clock.restart();
    GLfloat currentFrameRenderTime = elapsed.asMilliseconds();
    framesRenderTimeDelta = static_cast<GLfloat>(
        fabs(currentFrameRenderTime - previousFrameRenderTime));
    previousFrameRenderTime = currentFrameRenderTime;
  }
  Release();
  return 0;
}
