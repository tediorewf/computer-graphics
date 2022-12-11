#include "obj-parser.h"

#include <vector>
#include <string>
#include <sstream>
#include <fstream>
#include <stdexcept>
#include <iostream>

#include <glm/glm.hpp>
#include <GL/glew.h>

std::vector<Vertex> parse_obj(const std::string& filename)
{
	std::vector<glm::vec3> vertex_positions;
	std::vector<glm::vec2> vertex_texcoords;
	std::vector<glm::vec3> vertex_normals;

	std::vector<GLuint> vertex_position_indicies;
	std::vector<GLuint> vertex_texcoord_indicies;
	std::vector<GLuint> vertex_normal_indicies;

	std::stringstream ss;
	std::ifstream file(filename);
	std::string line, prefix;

	GLfloat x, y, z;
	GLfloat u, v;

	GLuint index;

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
			// Переворачиваем элемент v текстурной координаты
			vertex_texcoords.push_back(glm::vec2(u, 1 - v));
		}
		else if (prefix == "vn")
		{
			ss >> x >> y >> z;
			vertex_normals.push_back(glm::vec3(x, y, z));
		}
		else if (prefix == "f")
		{
			int current_facet_component = 0;
			while (ss >> index)
			{
				index -= 1; // Индексация в файле .obj с единицы. Нам надо с нуля

				if (current_facet_component == 0)
				{
					vertex_position_indicies.push_back(index);
				}
				else if (current_facet_component == 1)
				{
					vertex_texcoord_indicies.push_back(index);
				}
				else if (current_facet_component == 2)
				{
					vertex_normal_indicies.push_back(index);
				}

				if (ss.peek() == '/')
				{
					current_facet_component += 1;
					ss.ignore(1, '/');
				}
				else if (ss.peek() == ' ')
				{
					current_facet_component += 1;
					ss.ignore(1, ' ');
				}

				if (current_facet_component > 2)
				{
					current_facet_component = 0;
				}
			}
		}
	}

	std::vector<Vertex> vertices(vertex_position_indicies.size());

	for (size_t i = 0; i < vertices.size(); ++i)
	{
		vertices[i].position = vertex_positions[vertex_position_indicies[i]];
		vertices[i].texcoord = vertex_texcoords[vertex_texcoord_indicies[i]];
		vertices[i].normal = vertex_normals[vertex_normal_indicies[i]];
	}

	return vertices;
}
