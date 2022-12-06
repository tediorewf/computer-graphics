#define _CRT_SECURE_NO_WARNINGS

#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdio>
#include <list>
#include <sstream>

GLuint Program;
GLint Attrib_vertex;
GLint Attrib_color;
GLuint VBO;

struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;
};
struct TextureCoord
{
    GLfloat x;
    GLfloat y;
};

struct Figure
{
    std::list<Vertex> Vertexs;
    std::list <TextureCoord> TextureCoords;
};

const char* VertexShaderSource = R"(
    #version 330 core
    in vec3 coord;
    in vec3 color;
    out vec3 Vertexcolor;
    void main() {
        gl_Position = vec4(coord, 1.0);

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




Vertex* ReadVertexLine(char* lineHeader) {
    GLfloat x;
    GLfloat y;
    GLfloat z;
    std::istringstream(lineHeader) >> x >> y >> z;
    Vertex *V = new Vertex();
    V->x = x;
    V->y = y;
    V->z = z;
    return V;
}
TextureCoord* ReadTextureCoordLine(char* lineHeader) {
    GLfloat x;
    GLfloat y;
    std::istringstream(lineHeader) >> x >> y;
    TextureCoord* T = new TextureCoord();
    T->x = x;
    T->y = y;
    return T;
}

Figure* ReadFigure(std::string path) {
    FILE* file = fopen(path.c_str(), "r");

    if (file == NULL)
        std::cout << "NO FILE!";

    std::list<Vertex> Vertexs;
    std::list <TextureCoord> TextureCoords;
    while (1) {
        char lineHeader[128];
        int res = fscanf(file, "%s", lineHeader);
        if (res == EOF)
            break;
        else {
            if (strcmp(lineHeader, "v") == 0)
                Vertexs.push_back(*ReadVertexLine(lineHeader));
            else if (strcmp(lineHeader, "vt") == 0)
                TextureCoords.push_back(*ReadTextureCoordLine(lineHeader));
        }
    }
    Figure *F = new Figure();
    F->Vertexs = Vertexs;
    F->TextureCoords = TextureCoords;
    return F;
}


void InitVBO(float x, float y)
{
    glGenBuffers(1, &VBO);
    float t = 0.7;



    Figure *Figure = ReadFigure("Banana.obj");
    std::list<Vertex> Vertex = Figure->Vertexs;
    std::list <TextureCoord> TextureCoord = Figure->TextureCoords;




    //glBindBuffer(GL_ARRAY_BUFFER, VBO);
    //glBufferData(GL_ARRAY_BUFFER, sizeof(Figure), Figure, GL_STATIC_DRAW);
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

void Draw()
{
    glUseProgram(Program);

    glEnableVertexAttribArray(Attrib_vertex);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);

    // ������� � ������������
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);
    // ������� � ������

    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDrawArrays(GL_TRIANGLES, 0, 12);
    glDisableVertexAttribArray(Attrib_vertex);
    glUseProgram(0);
    checkOpenGLerror();
}

void Init(float x, float y)
{
    InitShader();
    InitVBO(x,y);
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

    glewInit();
    Init(0,0);
    float x = 0;
    float y = 0;
    float t = 0.1;
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
                        x -= t;
                        Init(x,y);
                        break;
                    case sf::Keyboard::Right:
                        x += t;
                        Init(x, y);
                        break;
                    case sf::Keyboard::Up:
                        y += t;
                        Init(x, y);
                        break;
                    case sf::Keyboard::Down:
                        y -= t;
                        Init(x, y);
                        break;
                }
            }
        }
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw();
        window.display();
    }
    Release();
    return 0;
}
