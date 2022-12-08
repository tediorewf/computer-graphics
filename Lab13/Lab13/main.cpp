#include "Vertex.h"
#include "obj-parser.h"

#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <SOIL/SOIL.h>
#include <glm/glm.hpp>
#include <glm/vec2.hpp>
#include <glm/vec3.hpp>
#include <glm/vec4.hpp>
#include <glm/mat4x4.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <iostream>

GLuint Program;
GLint Attrib_vertex_position, Attrib_vertex_texture_coordinate;
GLuint VBO, EBO;
GLuint texture0, texture1;

unsigned char* image_banana;
unsigned char* image_spider_monkey;

const char* VertexShaderSource = R"(
    #version 330 core

    in vec3 position;
    in vec2 texture_coordinate;

    out vec3 vs_position;
    out vec2 vs_texture_coordinate;

    uniform mat4 model;
    uniform mat4 view;
    uniform mat4 projection;

    void main() {
        vs_position = vec4(model * vec4(position, 1.0f)).xyz;
        vs_texture_coordinate = vec2(texture_coordinate.x, texture_coordinate.y * -1.0f);

        gl_Position = projection * view * model * vec4(position, 1.0f);
    }
)";

const char* FragShaderSource = R"(
    #version 330 core
    
    in vec3 vs_position;
    in vec2 vs_texture_coordinate;

    out vec4 color;

    uniform sampler2D texture;

    void main() {
        color = texture(texture, vs_texture_coordinate);
    }
)";

void checkOpenGLerror()
{
    GLenum err;
    while ((err = glGetError()) != GL_NO_ERROR)
    {
        std::cout << "GLerror Log: " << err << std::endl;
    }
}

Vertex vertices[] =
{
    								
    { glm::vec3(-0.5f, 0.5f, 0.f), glm::vec2(0.f, 1.f) },
    { glm::vec3(-0.5f, -0.5f, 0.f), glm::vec2(0.f, 0.f) },
    { glm::vec3(0.5f, -0.5f, 0.f), glm::vec2(1.f, 0.f) },
    { glm::vec3(0.5f, 0.5f, 0.f), glm::vec2(1.f, 1.f) }
};

unsigned num_vertices = sizeof(vertices) / sizeof(Vertex);

GLuint indices[] =
{
    0, 1, 2,
    0, 2, 3
};

unsigned num_indices = sizeof(indices) / sizeof(GLuint);

auto banana_mesh = parse_obj("Models/Spider_Monkey.obj");
auto monkey_mesh = parse_obj("Models/Spider_Monkey.obj");

void InitVBO()
{
    glGenBuffers(1, &VBO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(Vertex) * (monkey_mesh.size() + banana_mesh.size()), monkey_mesh.data(), GL_STATIC_DRAW);
    checkOpenGLerror();
}

void InitEBO()
{
    glGenBuffers(1, &EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(GLuint) * monkey_mesh.size(), NULL, GL_STATIC_DRAW);
}

void ShaderLog(unsigned int shader)
{
    int infologLen = 0;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        int charsWritten = 0;
        std::vector<char> infoLog(infologLen);
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
        std::cout << "InfoLog: " << infoLog.data() << std::endl;
    }
}

void InitShader()
{
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    ShaderLog(fShader);

    Program = glCreateProgram();

    glAttachShader(Program, vShader);
    glAttachShader(Program, fShader);

    glLinkProgram(Program);
    int link_ok;
    glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
    if (!link_ok)
    {
        std::cout << "error attach shaders \n";
        return;
    }

    const char* attr_name_position = "position";
    Attrib_vertex_position = glGetAttribLocation(Program, attr_name_position);
    if (Attrib_vertex_position == -1)
    {
        std::cout << "could not bind attrib " << attr_name_position << std::endl;
        return;
    }

    const char* attr_name_texture_coordinate = "texture_coordinate";
    Attrib_vertex_texture_coordinate = glGetAttribLocation(Program, attr_name_texture_coordinate);
    if (Attrib_vertex_texture_coordinate == -1)
    {
        std::cout << "could not bind attrib " << attr_name_texture_coordinate << std::endl;
        return;
    }

    checkOpenGLerror();
}

void InitTextures()
{
    int image_width_banana, image_height_banana;
    const char* filename_banana = "Textures/Banana.png";
    image_banana = SOIL_load_image(filename_banana, &image_width_banana, &image_height_banana, NULL, SOIL_LOAD_RGBA);
    glActiveTexture(GL_TEXTURE0);
    glGenTextures(1, &texture0);
    glBindTexture(GL_TEXTURE_2D, texture0);

    if (image_banana)
    {
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, image_width_banana, image_height_banana, 0, GL_RGBA, GL_UNSIGNED_BYTE, image_banana);
        glGenerateMipmap(GL_TEXTURE_2D);
    }
    else
    {
        std::cout << "could not load texture " << filename_banana << std::endl;
        return;
    }

    int image_width_spider_monkey, image_height_spider_monkey;
    const char* filename_spider_monkey = "Textures/Spider_Monkey.jpg";
    image_spider_monkey = SOIL_load_image(filename_spider_monkey, &image_width_spider_monkey, &image_height_spider_monkey, NULL, SOIL_LOAD_RGBA);
    glActiveTexture(GL_TEXTURE1);
    glGenTextures(1, &texture1);
    glBindTexture(GL_TEXTURE_2D, texture1);

    if (image_spider_monkey)
    {
        glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, image_width_spider_monkey, image_height_spider_monkey, 0, GL_RGBA, GL_UNSIGNED_BYTE, image_spider_monkey);
        glGenerateMipmap(GL_TEXTURE_2D);
    }
    else
    {
        std::cout << "could not load texture " << filename_spider_monkey << std::endl;
        return;
    }
}

GLfloat xAngle = 0, yAngle = 0, zAngle = 0;

GLuint windowWidth = 1200, windowHeight = 1200;

GLfloat cameraX = 0.f, cameraY = 0.f, cameraZ = 1.f;
GLfloat pitch = 0.0f, yaw = -90.0f, roll = 0.0f;  // Тангаж, расканье и крен

void Draw()
{
    glUseProgram(Program);

    glEnableVertexAttribArray(Attrib_vertex_position);
    glEnableVertexAttribArray(Attrib_vertex_texture_coordinate);

    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);

    glVertexAttribPointer(Attrib_vertex_position, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (GLvoid*)offsetof(Vertex, position));
    glVertexAttribPointer(Attrib_vertex_texture_coordinate, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (GLvoid*)offsetof(Vertex, texture_coordinate));

    glBindBuffer(GL_ARRAY_BUFFER, 0);

    glm::mat4 model(1.0f);
    model = glm::translate(model, glm::vec3(0.f, 0.f, 0.f));
    model = glm::rotate(model, glm::radians(xAngle), glm::vec3(1.f, 0.f, 0.f));
    model = glm::rotate(model, glm::radians(yAngle), glm::vec3(0.f, 1.f, 0.f));
    model = glm::rotate(model, glm::radians(zAngle), glm::vec3(0.f, 0.f, 1.f));
    model = glm::scale(model, glm::vec3(1.f));

    glm::vec3 camera_position(cameraX, cameraY, cameraZ);
    glm::vec3 camera_up(0.0f, 0.0f, 1.0f);
    glm::vec3 camera_front = glm::normalize(
        glm::vec3(
            cos(glm::radians(yaw)) * cos(glm::radians(pitch)),
            sin(glm::radians(pitch)),
            sin(glm::radians(yaw)) * cos(glm::radians(pitch))
        )
    );
    //glm::vec3 right = glm::normalize(glm::cross(camera_front, camera_up));

    glm::mat4 view(1.0f);
    view = glm::lookAt(camera_position, camera_position + camera_front, camera_up);

    GLfloat field_of_view = 90.0f;
    GLfloat near_plane = 0.1f;
    GLfloat far_plane = 1000.0f;
    glm::mat4 projection(1.0f);
    projection = glm::perspective(glm::radians(field_of_view), static_cast<GLfloat>(windowWidth) / windowHeight, near_plane, far_plane);

    glUniformMatrix4fv(glGetUniformLocation(Program, "model"), 1, GL_FALSE, glm::value_ptr(model));
    glUniformMatrix4fv(glGetUniformLocation(Program, "view"), 1, GL_FALSE, glm::value_ptr(view));
    glUniformMatrix4fv(glGetUniformLocation(Program, "projection"), 1, GL_FALSE, glm::value_ptr(projection));

    //glUniform1i(glGetUniformLocation(Program, "texture"), 0);
    glUniform1i(glGetUniformLocation(Program, "texture"), 1);
    glDrawArrays(GL_QUADS, 0, monkey_mesh.size());
    //glDrawElements(GL_TRIANGLES, num_indices, GL_UNSIGNED_INT, 0);

    glDisableVertexAttribArray(Attrib_vertex_position);
    glDisableVertexAttribArray(Attrib_vertex_texture_coordinate);

    glUseProgram(0);

    checkOpenGLerror();
}

void Init()
{
    InitShader();
    InitTextures();
    InitVBO();
    InitEBO();
}

void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO);
}

void ReleaseEBO()
{
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &EBO);
}

void ReleaseShader()
{
    glUseProgram(0);
    glDeleteProgram(Program);
}

void ReleaseTextures()
{
    glActiveTexture(0);
    glBindTexture(GL_TEXTURE_2D, 0);
    SOIL_free_image_data(image_banana);
    SOIL_free_image_data(image_spider_monkey);
}

void Release()
{
    ReleaseShader();
    ReleaseVBO();
    //ReleaseEBO();
    ReleaseTextures();
}

int main()
{
    sf::Window window(sf::VideoMode(windowWidth, windowHeight), "Solar System Model", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);
    window.setActive(true);

    glewInit();
    Init();
    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
            {
                window.close();
            }
            else if (event.type == sf::Event::Resized)
            {
                glViewport(0, 0, event.size.width, event.size.height);
                windowWidth = event.size.width;
                windowHeight = event.size.height;
            }
            else if (event.type == sf::Event::KeyPressed)
            {
                switch (event.key.code) 
                {
                case sf::Keyboard::A:
                    pitch += 5.0;
                    break;
                case sf::Keyboard::Z:
                    pitch -= 5.0;
                    break;
                case sf::Keyboard::S:
                    yaw += 5.0;
                    break;
                case sf::Keyboard::X:
                    yaw -= 5.0;
                    break;
                case sf::Keyboard::D:
                    roll += 5.0;
                    break;
                case sf::Keyboard::C:
                    roll -= 5.0;
                    break;
                case sf::Keyboard::G:
                    cameraX += 0.5;
                    break;
                case sf::Keyboard::B:
                    cameraX -= 0.5;
                    break;
                case sf::Keyboard::H:
                    cameraY += 0.5;
                    break;
                case sf::Keyboard::N:
                    cameraY -= 0.5;
                    break;
                case sf::Keyboard::J:
                    cameraZ += 0.5;
                    break;
                case sf::Keyboard::M:
                    cameraZ -= 0.5;
                    break;
                }
            }
        }
        glClearColor(0.1f, 0.6f, 0.2f, 1.f);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw();
        window.display();
    }
    Release();
    return 0;
}
