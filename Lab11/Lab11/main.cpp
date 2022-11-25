#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

GLuint Program1;
GLint Attrib_vertex1;
GLuint VBO1;

GLuint Program2;
GLint Attrib_vertex2;
GLuint VBO2;

struct Vertex
{
    GLfloat x;
    GLfloat y;
};

const char* VertexShaderSource1 = R"(
    #version 330 core
    in vec2 coord;
    void main() {
        gl_Position = vec4(coord/10, 0.0, 1.0);
    }
)";

const char* FragShaderSource1 = R"(
    #version 330 core
    const vec4 clr = vec4(0,1,2,1);
    out vec4 color;
    void main() {
        color = clr;
    }
)";

const char* VertexShaderSource2 = R"(
    #version 330 core
    in vec2 coord;
    void main() {
        gl_Position = vec4(coord/10, 0.0, 1.0);
    }
)";

const char* FragShaderSource2 = R"(
    #version 330 core
    uniform vec4 clr; 
    out vec4 color;
    void main() {
        color = clr;
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

// Инициализирует VBO для программы 1
void InitVBOProgram1()
{
    glGenBuffers(1, &VBO1);
    Vertex vertices1[20] = {
        // пятиугольник 1
        { -7.0f, 9.0f },
        { -4.0f, 9.0f },
        { -3.07f, 6.15f },
        { -5.5f, 4.38f },
        { -7.93f, 6.15f },

        // четырехугольник 1
        { -2.0f, 4.0f },
        { -2.0f, 9.0f },
        { 2.0f, 9.0f },
        { 2.0f, 4.0f },

        // веер 1
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
    };
    glBindBuffer(GL_ARRAY_BUFFER, VBO1);
    glBufferData(GL_ARRAY_BUFFER, sizeof(vertices1), vertices1, GL_STATIC_DRAW);
    checkOpenGLerror();
}

// Инициализирует VBO для программы 2
void InitVBOProgram2()
{
    glGenBuffers(1, &VBO2);
    Vertex vertices2[20]{
        // пятиугольник 2
        { -7.0f, -1.0f },
        { -4.0f, -1.0f },
        { -3.07f, -3.85f },
        { -5.5f, -5.62f },
        { -7.93f, -3.85f },

        // четырехугольник 2
        { -2.0f, -6.0f },
        { -2.0f, -1.0f },
        { 2.0f, -1.0f },
        { 2.0f, -6.0f },

        // веер 2
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
    glBindBuffer(GL_ARRAY_BUFFER, VBO2);
    glBufferData(GL_ARRAY_BUFFER, sizeof(vertices2), vertices2, GL_STATIC_DRAW);
    checkOpenGLerror();
}

void InitVBO()
{
    // Инициализация VBO для программы 1
    InitVBOProgram1();
    // Инициализация VBO для программы 2
    InitVBOProgram2();
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

// Инициализирует шейдеры для программы 1
void InitShaderProgram1()
{
    GLuint vShader1 = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vShader1, 1, &VertexShaderSource1, NULL);
    glCompileShader(vShader1);
    std::cout << "vertex shader \n";
    ShaderLog(vShader1);

    GLuint fShader1 = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fShader1, 1, &FragShaderSource1, NULL);
    glCompileShader(fShader1);
    std::cout << "fragment shader \n";
    ShaderLog(fShader1);

    Program1 = glCreateProgram();
    glAttachShader(Program1, vShader1);
    glAttachShader(Program1, fShader1);
    glLinkProgram(Program1);

    int link_ok1;
    glGetProgramiv(Program1, GL_LINK_STATUS, &link_ok1);
    if (!link_ok1)
    {
        std::cout << "error attach shaders \n";
        return;
    }
    const char* attr_name1 = "coord";
    Attrib_vertex1 = glGetAttribLocation(Program1, attr_name1);
    if (Attrib_vertex1 == -1)
    {
        std::cout << "could not bind attrib " << attr_name1 << std::endl;
        return;
    }
    checkOpenGLerror();
}

// Инициализирует шейдеры для программы 2
void InitShaderProgram2()
{
    GLuint fShader2 = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fShader2, 1, &FragShaderSource2, NULL);
    glCompileShader(fShader2);
    std::cout << "fragment shader \n";
    ShaderLog(fShader2);

    GLuint vShader2 = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vShader2, 1, &VertexShaderSource2, NULL);
    glCompileShader(vShader2);
    std::cout << "vertex shader \n";
    ShaderLog(vShader2);

    Program2 = glCreateProgram();
    glAttachShader(Program2, vShader2);
    glAttachShader(Program2, fShader2);
    glLinkProgram(Program2);

    int link_ok2;
    glGetProgramiv(Program2, GL_LINK_STATUS, &link_ok2);
    if (!link_ok2)
    {
        std::cout << "error attach shaders \n";
        return;
    }
    const char* attr_name2 = "coord";
    Attrib_vertex1 = glGetAttribLocation(Program2, attr_name2);
    if (Attrib_vertex1 == -1)
    {
        std::cout << "could not bind attrib " << attr_name2 << std::endl;
        return;
    }
    checkOpenGLerror();
}

void InitShader()
{
    // Инициализация шейдеров для программы 1
    InitShaderProgram1();
    // Инициализация шейдеров для программы 2
    InitShaderProgram2();
}

// Отрисовка для программы 1
void DrawProgram1()
{
    glUseProgram(Program1);
    glEnableVertexAttribArray(Attrib_vertex1);
    glBindBuffer(GL_ARRAY_BUFFER, VBO1);
    glVertexAttribPointer(Attrib_vertex1, 2, GL_FLOAT, GL_FALSE, 0, 0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    glDrawArrays(GL_POLYGON, 0, 5);
    glDrawArrays(GL_POLYGON, 5, 4);
    glDrawArrays(GL_TRIANGLE_FAN, 9, 11);

    glDisableVertexAttribArray(Attrib_vertex1);
    glUseProgram(0);
    checkOpenGLerror();
}

// Отрисовка для программы 2
void DrawProgram2()
{
    glUseProgram(Program2);
    glEnableVertexAttribArray(Attrib_vertex2);
    glBindBuffer(GL_ARRAY_BUFFER, VBO2);
    glVertexAttribPointer(Attrib_vertex2, 2, GL_FLOAT, GL_FALSE, 0, 0);
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    GLuint clrUniformLocation = glGetUniformLocation(Program2, "clr");

    glUniform4f(clrUniformLocation, 0, 0.2f, 0.3f, 1.0f);
    glDrawArrays(GL_POLYGON, 0, 5);

    glUniform4f(clrUniformLocation, 0, 0.3f, 0.5f, 1.0f);
    glDrawArrays(GL_POLYGON, 5, 4);

    glUniform4f(clrUniformLocation, 0, 0.6f, 0.8f, 0.5f);
    glDrawArrays(GL_TRIANGLE_FAN, 9, 11);

    glDisableVertexAttribArray(Attrib_vertex2);
    glUseProgram(0);
    checkOpenGLerror();
}

void Draw()
{
    // Программа 1
    DrawProgram1();
    // Программа 2
    DrawProgram2();
}

void Init()
{
    InitShader();
    InitVBO();
}

void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO1);
    glDeleteBuffers(1, &VBO2);
}

void ReleaseShader()
{
    glUseProgram(0);
    glDeleteProgram(Program1);
    glDeleteProgram(Program2);
}

void Release()
{
    ReleaseShader();
    ReleaseVBO();
}

int main()
{
    sf::Window window(sf::VideoMode(600, 600), 
        "Construction of various 2D shapes. Flat painting. Uniform", 
        sf::Style::Default, sf::ContextSettings(24));
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
