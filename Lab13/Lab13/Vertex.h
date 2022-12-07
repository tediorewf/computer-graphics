#ifndef VERTEX_H
#define VERTEX_H

#include <glm/glm.hpp>

struct Vertex 
{
	glm::vec3 position;
	glm::vec2 texture_coordinate;
	glm::vec3 normal;
};

#endif  // VERTEX_H
