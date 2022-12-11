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


Vertex* ReadVertexLine(std::string str) {
    char t[3];
    double x;
    double y;
    double z;
    std::istringstream(str) >>t>> x >> y >> z;
    Vertex *V = new Vertex();
    V->x = x;
    V->y = y;
    V->z = z;
    return V;
}
TextureCoord* ReadTextureCoordLine(std::string str) {
    char t[3];
    double x;
    double y;
    std::istringstream(str) >>t>> x >> y;
    TextureCoord* T = new TextureCoord();
    T->x = x;
    T->y = y;
    return T;
}
Figure* ReadFigure(std::string path) {
    std::fstream file(path);

    std::list<Vertex> Vertexs;
    std::list <TextureCoord> TextureCoords;
    
    std::string temp;
    while (!file.eof()) {
        std::getline(file, temp);

        if (temp[0] == 'v')
            if (temp[1] == 't')
                TextureCoords.push_back(*ReadTextureCoordLine(temp));
            else if (temp[1] == ' ')
                Vertexs.push_back(*ReadVertexLine(temp));
    }


    Figure *F = new Figure();
    F->Vertexs = Vertexs;
    F->TextureCoords = TextureCoords;
    return F;
}

int main()
{

    Figure* Figure = ReadFigure("Banana.obj");
    std::list<Vertex> Vertexs = Figure->Vertexs;
    std::list <TextureCoord> TextureCoords = Figure->TextureCoords;

    for (auto val : Vertexs)
        std::cout << val.x<<"; " << val.y << "; " << val.z << "; " << std::endl;
    for (auto val : TextureCoords)
        std::cout << val.x << "; " << val.y << "; "<< std::endl;

}
