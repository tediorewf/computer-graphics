#ifndef MODEL_H
#define MODEL_H

#include <vector>

#include <glm/glm.hpp>
#include <GL/glew.h>

struct Model 
{
	// ��� ��� VBO
	std::vector<Vertex> vertices;
	// ��� ��� EBO
	std::vector<GLuint> vertex_indicies;
};

#endif  // MODEL_H
