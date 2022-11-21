#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

GLuint Program;
GLint Attrib_vertex;
GLuint VBO;

struct Vertex
{
    GLfloat x;
    GLfloat y;
};

const char* VertexShaderSource = R"(
    #version 330 core
    in vec2 coord;
    void main() {
        gl_Position = vec4(coord/10, 0.0, 1.0);
    }
)";

const char* FragShaderSource = R"(
    #version 330 core
    out vec4 color;
    void main() {
        color = vec4(1, 1, 1, 1);
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
    Vertex triangle[40] = {
        //пятиугольник 1
        { -7.0f, 9.0f },
        { -4.0f, 9.0f },
        { -3.07f, 6.15f },
        { -5.5f, 4.38f },
        { -7.93f, 6.15f },

        //четырехугольник 1
        { -2.0f, 4.0f },
        { -2.0f, 9.0f },
        { 2.0f, 9.0f },
        { 2.0f, 4.0f },

        //веер 1
        { 4.0f , 4.0f },
        { 4.0f , 2.0f },
        { 5.0f , 2.0f },
        { 6.98f , 2.28f },
        { 8.05f , 3.28f },
        { 8.2f , 4.44f },
        { 8.43 , 5.75f },
        { 8.0f , 7.0f },
        { 7.58f , 8.35f },
        { 6.0f , 9.0f },
        { 4.0f , 9.0f},

        //пятиугольник 2
        { -7.0f, -1.0f },
        { -4.0f, -1.0f },
        { -3.07f, -3.85f },
        { -5.5f, -5.62f },
        { -7.93f, -3.85f },

        //четырехугольник 2
        { -2.0f, -6.0f },
        { -2.0f, -1.0f },
        { 2.0f, -1.0f },
        { 2.0f, -6.0f },

        //веер 2
        { 4.0f , -6.0f },
        { 4.0f , -8.0f },
        { 5.0f , -8.0f },
        { 6.98f , -7.72f },
        { 8.05f , -6.72f },
        { 8.2f , -5.56f },
        { 8.43 , -4.25f },
        { 8.0f , -3.0f },
        { 7.58f , -1.65f },
        { 6.0f , -1.0f },
        { 4.0f , -1.0f}
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
    checkOpenGLerror();
}

void Draw()
{
    glUseProgram(Program);
    glEnableVertexAttribArray(Attrib_vertex);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    glDrawArrays(GL_POLYGON, 0, 5);
    glDrawArrays(GL_POLYGON, 5, 4);
    glDrawArrays(GL_TRIANGLE_FAN, 9, 11);

    glDrawArrays(GL_POLYGON, 20, 5);
    glDrawArrays(GL_POLYGON, 25, 4);
    glDrawArrays(GL_TRIANGLE_FAN, 29, 11);

    glDisableVertexAttribArray(Attrib_vertex);
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
    sf::Window window(sf::VideoMode(600, 600), "Green Triangle", sf::Style::Default, sf::ContextSettings(24));
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
            }
        }
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw();
        window.display();
    }
    Release();
    return 0;
}
