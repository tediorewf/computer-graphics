#ifndef OBJ_PARSER_H
#define OBJ_PARSER_H

#include "Vertex.h"

#include <vector>
#include <string>
#include <sstream>
#include <fstream>
#include <stdexcept>

#include <glm/glm.hpp>
#include <GL/glew.h>

std::vector<Vertex> parse_obj(const std::string& filename)
{
	std::vector<glm::vec3> vertex_positions;
	std::vector<glm::vec2> vertex_texture_coordinates;
	std::vector<glm::vec3> vertex_normals;

	std::vector<GLint> vertex_position_indicies;
	std::vector<GLint> vertex_texcoord_indicies;
	std::vector<GLint> vertex_normal_indicies;

	std::stringstream ss;
	std::ifstream file(filename);
	std::string line, prefix;

	GLfloat x, y, z;
	GLfloat u, v;

	GLint index;

	if (!file.good()) 
	{
		throw std::logic_error("Unable to read the given .obj file");
	}

	while (std::getline(file, line)) 
	{
		ss.clear();
		ss.str(line);
		ss >> prefix;

		if (prefix == "v")
		{
			ss >> x >> y >> z;
			vertex_positions.push_back(glm::vec3(x, y, z));
		}
		else if (prefix == "vt")
		{
			ss >> u >> v;
			vertex_texture_coordinates.push_back(glm::vec2(u, v));
		}
		else if (prefix == "vn")
		{
			ss >> x >> y >> z;
			vertex_normals.push_back(glm::vec3(x, y, z));
		}
		else if (prefix == "f")
		{
			int count = 0;
			while (ss >> index)
			{
				if (count == 0)
				{
					vertex_position_indicies.push_back(index);
				}
				else if (count == 1)
				{
					vertex_texcoord_indicies.push_back(index);
				}
				else if (count == 2)
				{
					vertex_normal_indicies.push_back(index);
				}

				if (ss.peek() == '/')
				{
					count += 1;
					ss.ignore(1, '/');
				}
				else if (ss.peek() == ' ')
				{
					count += 1;
					ss.ignore(1, ' ');
				}

				if (count > 2)
				{
					count = 0;
				}
			}
		}
	}

	std::vector<Vertex> vertices(vertex_position_indicies.size());

	for (size_t i = 0; i < vertices.size(); ++i)
	{
		vertices[i].position = vertex_positions[vertex_position_indicies[i] - 1];
		vertices[i].texture_coordinate = vertex_texture_coordinates[vertex_texcoord_indicies[i] - 1];
		vertices[i].normal = vertex_normals[vertex_normal_indicies[i] - 1];
	}

	return vertices;
}

#endif  // OBJ_PARSER_H
