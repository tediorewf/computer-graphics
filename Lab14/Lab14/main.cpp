#include "Vertex.h"
#include "obj-parser.h"

#include <GL/glew.h>
#include <SFML/Graphics.hpp>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SOIL/SOIL.h>
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glm/mat4x4.hpp>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>

#include <iostream>

GLuint Program;

GLint Attrib_vertex_position;
GLuint Attrib_vertex_texture_coordinate;
GLint Attrib_vertex_normal;

GLuint VBO;
GLuint textures[5];

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

const char *FragmentShaderSource = R"(
    #version 330 core
    
    in vec3 vs_position;
    in vec2 vs_texcoord;
    in vec3 vs_normal;   

    out vec4 color;

    uniform vec3 point_light_position;
    uniform vec3 direction_light_position;
    uniform vec3 spot_light_position;
    uniform vec3 view_position;

    uniform sampler2D texture;

    uniform int lighting_type;

    vec4 calculate_point_light()
    {
	    vec3 light = point_light_position - vs_position;

	    float distance = length(light);
	    float a = 1.6f;
	    float b = 0.4f;
	    float intensivity = 1.0f / (a * distance * distance + b * distance + 1.0f);

	    float ambient = 0.20f;

	    vec3 normal = normalize(vs_normal);
	    vec3 light_direction = normalize(light);
	    float diffuse = max(dot(normal, light_direction), 0.0f);

	    float specular_light = 0.50f;
	    vec3 view_direction = normalize(view_position - vs_position);
	    vec3 reflection_direction = reflect(-light_direction, normal);
	    float spec_amount = pow(max(dot(view_direction, reflection_direction), 0.0f), 8);
	    float specular = spec_amount * specular_light;

	    return texture(texture, vs_texcoord) * (diffuse * intensivity + ambient) + texture(texture, vs_texcoord).r * specular * intensivity;
    }

    vec4 calculate_direction_light()
    {
	    float ambient = 0.10f;

	    vec3 normal = normalize(vs_normal);
	    vec3 light_direction = normalize(direction_light_position);
	    float diffuse = max(dot(normal, light_direction), 0.0f);

	    float specular_light = 0.20f;
	    vec3 view_direction = normalize(view_position - vs_position);
	    vec3 reflection_direction = reflect(-light_direction, normal);
	    float spec_amount = pow(max(dot(view_direction, reflection_direction), 0.0f), 8);
	    float specular = spec_amount * specular_light;

	    return texture(texture, vs_texcoord) * (diffuse + ambient) + texture(texture, vs_texcoord).r * specular;
    }

    vec4 calculate_toon(vec3 light_position)
    {
        vec4 diffColor = texture(texture, vs_texcoord);

        vec3 n2 = normalize(vs_normal);
        vec3 l2 = normalize(light_position);
        float diff = 0.2f + max(dot(n2, l2), 0.0f);
        if (diff < 0.4f)
        {
            diffColor = diffColor * 0.3f + vec4(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (diff < 0.7f)
        {
            diffColor = diffColor;
        }
        else        
        {
            diffColor = diffColor * 1.3f;
        }
        return diffColor;
    }

    vec4 calculate_minnaert(vec3 light_position)
    {
        vec4 diffColor = texture(texture, vs_texcoord);
        float k = 0.8;
        vec3 n2 = normalize(vs_normal);
        vec3 l2 = normalize(light_position);
        vec3 v2 = normalize(view_position);
        float d1 = pow(max(dot(n2 , l2), 0.0f), 1.0f + k);
        float d2 = pow(1.0f - dot(n2, v2), 1.0f - k);
        return diffColor * d1 * d2 + vec4(0.0f, 0.0f, 0.0f, 1.0f);
    }

    void main() {
        switch (lighting_type) {
        case 0:
            color = calculate_toon(point_light_position);
            color += calculate_point_light();
            color += calculate_toon(direction_light_position);
            color += calculate_direction_light();
            break;
        case 1:
            color = calculate_minnaert(point_light_position);
            color = calculate_point_light();
            color += calculate_minnaert(direction_light_position);
            color += calculate_direction_light();
            break;
        default:
            color = vec4(0.1f, 0.2f, 0.3f, 1.0f);
            break;
        }
    }
)";

void checkOpenGLerror() {
  GLenum err;
  while ((err = glGetError()) != GL_NO_ERROR) {
    std::cout << "GLerror Log: " << err << std::endl;
  }
}

// Банан
auto banana_mesh = parse_obj("Models/banana.obj");
// Пол
auto floor_mesh =
    std::vector<Vertex>{{glm::vec3(0.0f, 0.0f, 0.0f), glm::vec2(0.0f, 0.0f),
                         glm::vec3(0.0f, 0.0f, 1.0f)},
                        {glm::vec3(1000.0f, 0.0f, 0.0f), glm::vec2(1.0f, 0.0f),
                         glm::vec3(1.0f, 0.0f, 1.0f)},
                        {glm::vec3(1000.0f, 1000.0f, 0.0f),
                         glm::vec2(1.0f, 1.0f), glm::vec3(1.0f, 1.0f, 1.0f)},

                        {glm::vec3(0.0f, 0.0f, 0.0f), glm::vec2(0.0f, 0.0f),
                         glm::vec3(0.0f, 0.0f, 1.0f)},
                        {glm::vec3(1000.0f, 1000.0f, 0.0f),
                         glm::vec2(1.0f, 1.0f), glm::vec3(1.0f, 1.0f, 1.0f)},
                        {glm::vec3(0.0f, 1000.0f, 0.0f), glm::vec2(0.0f, 1.0f),
                         glm::vec3(0.0f, 1.0f, 1.0f)}};
// Яблоко
auto apple_mesh = parse_obj("Models/apple.obj");
// Стул
auto chair_mesh = parse_obj("Models/chair.obj");
// Стол
auto table_mesh = parse_obj("Models/table.obj");

void InitVBOs() {
  auto scene = std::vector<Vertex>();
  const std::size_t sceneSize =
      banana_mesh.size() + floor_mesh.size() + apple_mesh.size();
  scene.reserve(sceneSize);
  scene.insert(scene.end(), banana_mesh.begin(), banana_mesh.end());
  scene.insert(scene.end(), floor_mesh.begin(), floor_mesh.end());
  scene.insert(scene.end(), apple_mesh.begin(), apple_mesh.end());
  scene.insert(scene.end(), chair_mesh.begin(), chair_mesh.end());
  scene.insert(scene.end(), table_mesh.begin(), table_mesh.end());

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

void InitShaders() {
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

void _loadTextures(const std::vector<const char *> imageNames) {
  for (GLuint unit = 0; unit < imageNames.size(); unit += 1) {
    _load_texture(imageNames[unit], unit, textures[unit]);
  }
}

void InitTextures() {
  _loadTextures({
      "Textures/banana.png",
      "Textures/laminate.jpg",
      "Textures/apple.jpeg",
      "Textures/chair.png",
      "Textures/table.jpeg",
  });
}

GLuint windowWidth = 1200, windowHeight = 1200;

GLfloat cameraX = -40.0f, cameraY = -100.0f, cameraZ = 110.0f;
GLfloat pitch = 40.0f, yaw = 325.0f, roll = 355.0f; // Тангаж, рысканье и крен

GLfloat pointLightX = -1.0f;
GLfloat pointLightY = -1.0f;
GLfloat pointLightZ = 0.0f;

GLfloat directionLightX = 1.0f;
GLfloat directionLightY = 1.0f;
GLfloat directionLightZ = 0.0f;

GLfloat spotLightX = 0;
GLfloat spotLightY = 0;
GLfloat spotLightZ = 30.0f;

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

  // glm::mat4 model(1.0f);
  // model = glm::translate(model, glm::vec3(-500.f, -250.f, 0.f));
  // model = glm::rotate(model, glm::radians(xAngle), glm::vec3(1.f, 0.f, 0.f));
  // model = glm::rotate(model, glm::radians(yAngle), glm::vec3(0.f, 1.f, 0.f));
  // model = glm::rotate(model, glm::radians(zAngle), glm::vec3(0.f, 0.f, 1.f));
  // model = glm::scale(model, glm::vec3(1.0f));

  glm::vec3 camera_position(cameraX, cameraY, cameraZ);
  glm::vec3 camera_up(0.0f, 0.0f, 1.0f);
  glm::vec3 camera_front = glm::normalize(
      glm::vec3(cos(glm::radians(yaw)) * cos(glm::radians(pitch)),
                sin(glm::radians(pitch)),
                sin(glm::radians(yaw)) * cos(glm::radians(pitch))));

  glm::mat4 view(1.0f);
  view =
      glm::lookAt(camera_position, camera_position + camera_front, camera_up);

  GLfloat field_of_view = 60.0f;
  GLfloat near_plane = 0.01f;
  GLfloat far_plane = 10000.0f;
  glm::mat4 projection(1.0f);
  projection = glm::perspective(
      glm::radians(field_of_view),
      static_cast<GLfloat>(windowWidth) / windowHeight, near_plane, far_plane);

  glUniformMatrix4fv(glGetUniformLocation(Program, "view"), 1, GL_FALSE,
                     glm::value_ptr(view));
  glUniformMatrix4fv(glGetUniformLocation(Program, "projection"), 1, GL_FALSE,
                     glm::value_ptr(projection));
  glUniform3f(glGetUniformLocation(Program, "view_position"), cameraX, cameraY,
              cameraZ);
  glUniform3f(glGetUniformLocation(Program, "point_light_position"),
              pointLightX, pointLightY, pointLightZ);
  glUniform3f(glGetUniformLocation(Program, "direction_light_position"),
              directionLightX, directionLightY, directionLightZ);
  glUniform3f(glGetUniformLocation(Program, "spot_light_position"), spotLightX,
              spotLightY, spotLightZ);

  glUniform1i(glGetUniformLocation(Program, "lighting_type"), 0);
  glm::mat4 modelBanana0(1.0f);
  modelBanana0 = glm::translate(modelBanana0, glm::vec3(100.f, 40.f, 20.f));
  modelBanana0 = glm::rotate(modelBanana0, glm::radians(23.0f),
                             glm::vec3(0.0f, 0.0f, 1.0f));
  const GLuint bananaFirst0 = 0;
  drawMesh(GL_TRIANGLES, 0, bananaFirst0, banana_mesh.size(), modelBanana0);

  glUniform1i(glGetUniformLocation(Program, "lighting_type"), 1);
  glm::mat4 modelBanana1(1.0f);
  modelBanana1 = glm::translate(modelBanana1, glm::vec3(331.f, 72.f, 18.f));
  modelBanana1 = glm::rotate(modelBanana1, glm::radians(47.0f),
                             glm::vec3(0.0f, 0.0f, 1.0f));
  const GLuint bananaFirst1 = 0;
  drawMesh(GL_TRIANGLES, 0, bananaFirst1, banana_mesh.size(), modelBanana1);

  glUniform1i(glGetUniformLocation(Program, "lighting_type"), 0);
  glm::mat4 modelFloor(1.0f);
  modelFloor = glm::translate(modelFloor, glm::vec3(0.0f, 0.0f, 0.0f));
  const GLuint planeFirst = banana_mesh.size();
  drawMesh(GL_TRIANGLES, 1, planeFirst, floor_mesh.size(), modelFloor);

  glUniform1i(glGetUniformLocation(Program, "lighting_type"), 1);
  glm::mat4 modelApple(1.0f);
  modelApple = glm::translate(modelApple, glm::vec3(250.f, 390.f, 90.f));
  modelApple = glm::rotate(modelApple, glm::radians(180.0f),
                           glm::vec3(10.f, 0.0f, 0.0f));
  modelApple = glm::scale(modelApple, glm::vec3(5.0f));
  const GLuint appleFirst = banana_mesh.size() + floor_mesh.size();
  drawMesh(GL_TRIANGLES, 2, appleFirst, apple_mesh.size(), modelApple);

  glUniform1i(glGetUniformLocation(Program, "lighting_type"), 0);
  glm::mat4 modelChair(1.0f);
  modelChair = glm::translate(modelChair, glm::vec3(195.0f, 200.0f, 163.0f));
  modelChair = glm::scale(modelChair, glm::vec3(20.0f));
  modelChair =
      glm::rotate(modelChair, glm::radians(90.0f), glm::vec3(1.0f, 0.0f, 0.0f));
  const GLuint chairFirst =
      banana_mesh.size() + floor_mesh.size() + apple_mesh.size();
  drawMesh(GL_TRIANGLES, 3, chairFirst, chair_mesh.size(), modelChair);

  glm::mat4 modelTable(1.0f);
  modelTable = glm::translate(modelTable, glm::vec3(180, 275.0f, 5.0f));
  modelTable = glm::scale(modelTable, glm::vec3(0.22f));
  modelTable =
      glm::rotate(modelTable, glm::radians(90.0f), glm::vec3(1.0f, 0.0f, 0.0f));
  const GLuint tableFirst = banana_mesh.size() + floor_mesh.size() +
                            apple_mesh.size() + chair_mesh.size();
  drawMesh(GL_TRIANGLES, 4, tableFirst, table_mesh.size(), modelTable);

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
  InitShaders();
  InitTextures();
  InitVBOs();
}

void ReleaseVBO() {
  glBindBuffer(GL_ARRAY_BUFFER, 0);
  glDeleteBuffers(1, &VBO);
}

void ReleaseShaders() {
  glUseProgram(0);
  glDeleteProgram(Program);
}

void Release() {
  ReleaseShaders();
  ReleaseVBO();
}

int main() {
  sf::Window window(sf::VideoMode(windowWidth, windowHeight), "Lighting",
                    sf::Style::Default, sf::ContextSettings(24));
  window.setVerticalSyncEnabled(true);
  window.setActive(true);

  glewInit();
  Init();
  while (window.isOpen()) {
    sf::Event event;
    while (window.pollEvent(event)) {
      if (event.type == sf::Event::Closed) {
        window.close();
      } else if (event.type == sf::Event::Resized) {
        glViewport(0, 0, event.size.width, event.size.height);
        windowWidth = event.size.width;
        windowHeight = event.size.height;
      } else if (event.type == sf::Event::KeyPressed) {
        switch (event.key.code) {
        case sf::Keyboard::A:
          pitch += 5.0f;
          break;
        case sf::Keyboard::Z:
          pitch -= 5.0f;
          break;
        case sf::Keyboard::S:
          yaw += 5.0f;
          break;
        case sf::Keyboard::X:
          yaw -= 5.0f;
          break;
        case sf::Keyboard::D:
          roll += 5.0f;
          break;
        case sf::Keyboard::C:
          roll -= 5.0f;
          break;
        case sf::Keyboard::G:
          cameraX += 10.0f;
          break;
        case sf::Keyboard::B:
          cameraX -= 10.0f;
          break;
        case sf::Keyboard::H:
          cameraY += 10.0f;
          break;
        case sf::Keyboard::N:
          cameraY -= 10.0f;
          break;
        case sf::Keyboard::J:
          cameraZ += 10.0;
          break;
        case sf::Keyboard::M:
          cameraZ -= 10.0;
          break;
        // Point ligh position
        case sf::Keyboard::T:
          pointLightX += 1.0f;
          break;
        case sf::Keyboard::Y:
          pointLightX -= 1.0f;
          break;
        case sf::Keyboard::U:
          pointLightY += 1.0f;
          break;
        case sf::Keyboard::I:
          pointLightY -= 1.0f;
          break;
        case sf::Keyboard::O:
          pointLightZ += 1.0f;
          break;
        case sf::Keyboard::P:
          pointLightZ -= 1.0f;
          break;
        }
      }
    }
    glClearColor(0.1f, 0.6f, 0.2f, 1.f);
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    Draw();
    window.display();
    /*
    std::cout << "X " << cameraX << std::endl;
    std::cout << "Y " << cameraY << std::endl;
    std::cout << "Z " << cameraZ << std::endl;
    std::cout << "pitch " << pitch << std::endl;
    std::cout << "yaw " << yaw << std::endl;
    std::cout << "roll " << roll << std::endl;
    */
  }
  Release();
  return 0;
}
