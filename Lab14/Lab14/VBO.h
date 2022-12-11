#ifndef VBO_H
#define VBO_H

#include "Vertex.h"

#include <vector>

#include <gl/glew.h>

class VBO
{
	GLuint vboId;
	GLsizei verticesCount;

	void initVBO(const std::vector<Vertex>& vertices)
	{
		glGenBuffers(1, &vboId);
		glBindBuffer(GL_ARRAY_BUFFER, vboId);
		glBufferData(GL_ARRAY_BUFFER, sizeof(Vertex) * vertices.size(), vertices.data(), GL_STATIC_DRAW);
	}
public:
	VBO(const std::vector<Vertex>& vertices)
		: verticesCount(vertices.size())
	{
		initVBO(vertices);
	}

	GLsizei GetVerticesCount()
	{
		return this->verticesCount;
	}

	void Bind()
	{
		glBindBuffer(GL_ARRAY_BUFFER, vboId);
	}

	void Unbind()
	{
		glBindBuffer(GL_ARRAY_BUFFER, 0);
	}

	void Delete()
	{
		glDeleteBuffers(1, &vboId);
	}

	GLuint GetID()
	{
		return this->vboId;
	}
};

#endif // VBO_H
