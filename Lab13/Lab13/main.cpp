#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <glm/mat4x4.hpp> 
#include <glm/gtc/type_ptr.hpp>

GLuint Program;
GLint Attrib_vertex;
GLint Attrib_color;
GLuint VBO;

struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;

    GLfloat r;
    GLfloat g;
    GLfloat b;
};

const char* VertexShaderSource = R"(
    #version 330 core
    in vec3 coord;
    in vec3 color;
    out vec3 Vertexcolor;

    uniform mat4 Transform;

    void main() {
        gl_Position = Transform * vec4(coord, 1.0f);

        Vertexcolor = color;
    }
)";

const char* FragShaderSource = R"(
    #version 330 core
    in vec3 Vertexcolor;
    out vec4 color;
    void main() {
        color = vec4(Vertexcolor , 0);
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

void InitVBO()
{
    glGenBuffers(1, &VBO);
    float t = 0.7;
    Vertex triangle[] = {
        {0,0 ,0, 3, 1, 0},
        {t ,0,0, 0.5, 2, 1},
        {t / 2 ,t * sqrt(3) / 2 ,0, 1, 0, 0.5},

        {0 ,0 ,0, 3, 1, 0},
        {t ,0 ,0, 0.5, 2, 1},
        {t / 2 ,t * sqrt(3) / 6 ,t * sqrt(2) / 3, 0.5, 0, 0.5},

        {0 ,0 ,0, 3, 1, 0},
        {t / 2 ,t * sqrt(3) / 2 ,0, 1, 0, 0.5},
        {t / 2 ,t * sqrt(3) / 6 ,t * sqrt(2) / 3, 0.5, 0, 0.5},

        {t ,0 ,0, 0.5, 2, 1},
        {t / 2 ,t * sqrt(3) / 2 ,0, 1, 0, 0.5},
        {t / 2 ,t * sqrt(3) / 6 ,t * sqrt(2) / 3, 0.5, 0, 0.5},
    };
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    checkOpenGLerror();
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
    const char* attr_name = "coord";
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }
    const char* attr_name1 = "color";
    Attrib_color = glGetAttribLocation(Program, attr_name1);
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib " << attr_name1 << std::endl;
        return;
    }
    checkOpenGLerror();
}


glm::mat4 Camera(float Mashtab, float OX, float OY,float Rx,float Ry)
{
    glm::mat4 RotateY = glm::mat4(cos(Ry), 0, -sin(Ry), 0, 0, 1, 0, 0, sin(Ry), 0, cos(Ry), 0, 0, 0, 0, 1);
    glm::mat4 RotateX = glm::mat4(1, 0, 0, 0, 0, cos(Rx), sin(Rx), 0, 0, -sin(Rx), cos(Rx), 0, 0, 0, 0, 1);
    int c = 10;
    glm::mat4 Projection = glm::mat4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1/c, 0, 0, 0, 1);
    glm::mat4 Trans = glm::mat4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, -OX, -OY, Mashtab, 1);
    return  Trans * RotateY * RotateX * Projection;
}


void Draw(float Mashtab, float OX, float OY, float Rx, float Ry)
{
    glUseProgram(Program);

    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);

    // Атрибут с координатами
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);
    // Атрибут с цветом
    glVertexAttribPointer(Attrib_color, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));

    GLint TransformLoc = glGetUniformLocation(Program, "Transform");
    glm::mat4 Transform = Camera(Mashtab, OX, OY, Rx, Ry);
    glUniformMatrix4fv(TransformLoc, 1, GL_FALSE, glm::value_ptr(Transform));


    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDrawArrays(GL_TRIANGLES, 0, 12);
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);
    glUseProgram(0);
    checkOpenGLerror();
}


void Init()
{
    InitShader();
    InitVBO();
}

void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO);
}

void ReleaseShader()
{
    glUseProgram(0);
    glDeleteProgram(Program);
}

void Release()
{
    ReleaseShader();
    ReleaseVBO();
}

int main()
{
    sf::Window window(sf::VideoMode(600, 600), "12", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);
    window.setActive(true);

    float Mashtab = 0;
    float OX = 0;
    float OY = 0;
    float Rx = 0;
    float Ry = 0;
    float delta = 0.1;

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
            }
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                    case sf::Keyboard::Left:
                        OX -= delta;
                        break;
                    case sf::Keyboard::Right:
                        OX += delta;
                        break;
                    case sf::Keyboard::Up:
                        OY += delta;
                        break;
                    case sf::Keyboard::Down:
                        OY -= delta;
                        break;
                    case sf::Keyboard::LBracket:
                        Mashtab += delta;
                        break;
                    case sf::Keyboard::RBracket:
                        Mashtab -= delta;
                        break;
                    case sf::Keyboard::O:
                        Rx -= delta*10;
                        break;
                    case sf::Keyboard::P:
                        Ry -= delta*10;
                        break;
                }
            }
        }
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw(Mashtab, OX, OY, Rx, Ry);
        window.display();
    }
    Release();
    return 0;
}
