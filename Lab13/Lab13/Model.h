#ifndef MODEL_H
#define MODEL_H

#include <vector>

#include <glm/glm.hpp>
#include <GL/glew.h>

struct Model 
{
	// Это для VBO
	std::vector<Vertex> vertices;
	// Это для EBO
	std::vector<GLuint> vertex_indicies;
};

#endif  // MODEL_H
