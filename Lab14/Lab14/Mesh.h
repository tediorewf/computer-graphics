#ifndef MESH_H
#define MESH_H

#include "Vertex.h"
#include "Texture.h"
#include "ShaderProgram.h"
#include "Camera.h"
#include "VBO.h"
#include "utils.h"

#include <vector>

#include <glm/glm.hpp>
#include <gl/GL.h>

class Mesh
{
	VBO vbo;
	Texture texture;
public:
	Mesh(VBO& vbo, const Texture& texture)
		: vbo(vbo), texture(texture)
	{
	}

	void Draw(ShaderProgram& shaderProgram, Camera& camera, glm::mat4 modelMatrix, glm::mat4 projectionMatrix)
	{
		shaderProgram.Use();
		shaderProgram.EnableVertexAttributes();

		vbo.Bind();

		shaderProgram.DefineVertexAttributes();

		vbo.Unbind();

		shaderProgram.AssignModelMatrix(modelMatrix);
		shaderProgram.AssignProjectionMatrix(projectionMatrix);

		texture.Assign(shaderProgram, "texture");
		glDrawArrays(GL_TRIANGLES, 0, vbo.GetVerticesCount());

		shaderProgram.DisableVertexAttributes();
		shaderProgram.Unuse();

		checkOpenGLerror();
	}
};

#endif // MESH_H
