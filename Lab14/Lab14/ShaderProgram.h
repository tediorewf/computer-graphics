#ifndef SHADER_PROGRAM_H
#define SHADER_PROGRAM_H

#include "utils.h"

#include <string>
#include <iostream>

#include <gl/glew.h>
#include <glm/glm.hpp>
#include <glm/gtc/type_ptr.hpp>

class ShaderProgram
{
	const char* vertexShaderSource;
	const char* fragmentShaderSource;
	GLuint Program;
	GLuint vShader, fShader;
	GLuint positionLocation, texcoordLocation, normalLocation;

	void initShaders()
	{
		vShader = glCreateShader(GL_VERTEX_SHADER);
		glShaderSource(vShader, 1, &vertexShaderSource, NULL);
		glCompileShader(vShader);
		std::cout << "vertex shader \n";
		ShaderLog(vShader);

		fShader = glCreateShader(GL_FRAGMENT_SHADER);
		glShaderSource(fShader, 1, &fragmentShaderSource, NULL);
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
		}

		bindVertexAttributes();

		checkOpenGLerror();
	}

	void bindVertexAttributes()
	{
		const char* attr_position = "position";
		positionLocation = glGetAttribLocation(Program, attr_position);
		if (positionLocation == -1)
		{
			std::cout << "could not bind attrib " << attr_position << std::endl;
		}

		const char* attr_texcoord = "texcoord";
		texcoordLocation = glGetAttribLocation(Program, attr_texcoord);
		if (texcoordLocation == -1)
		{
			std::cout << "could not bind attrib " << attr_texcoord << std::endl;
		}

		const char* attr_normal = "normal";
		normalLocation = glGetAttribLocation(Program, attr_normal);
		if (normalLocation == -1)
		{
			std::cout << "could not bind attrib " << attr_normal << std::endl;
		}
	}
public:
	ShaderProgram(const char* vertexShaderSource, const char* fragmentShaderSource)
		: vertexShaderSource(vertexShaderSource), fragmentShaderSource(fragmentShaderSource)
	{
		initShaders();
	}

	GLuint GetID()
	{
		return this->Program;
	}

	void Use()
	{
		glUseProgram(Program);
	}

	void Unuse()
	{
		glUseProgram(0);
	}

	void Delete()
	{
		glDeleteProgram(Program);
	}

	void EnableVertexAttributes()
	{
		glEnableVertexAttribArray(positionLocation);
		glEnableVertexAttribArray(texcoordLocation);
		glEnableVertexAttribArray(normalLocation);
	}

	void DefineVertexAttributes()
	{
		glVertexAttribPointer(positionLocation, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (GLvoid*)offsetof(Vertex, position));
		glVertexAttribPointer(texcoordLocation, 2, GL_FLOAT, GL_FALSE, sizeof(Vertex), (GLvoid*)offsetof(Vertex, texcoord));
		glVertexAttribPointer(normalLocation, 3, GL_FLOAT, GL_FALSE, sizeof(Vertex), (GLvoid*)offsetof(Vertex, normal));
	}

	void DisableVertexAttributes()
	{
		glDisableVertexAttribArray(positionLocation);
		glDisableVertexAttribArray(texcoordLocation);
		glDisableVertexAttribArray(normalLocation);
	}

	void AssignModelMatrix(glm::mat4 modelMatrix) 
	{
		glUniformMatrix4fv(glGetUniformLocation(Program, "model"), 1, GL_FALSE, glm::value_ptr(modelMatrix));
	}

	void AssignViewMatrix(glm::mat4 viewMatrix)
	{
		glUniformMatrix4fv(glGetUniformLocation(Program, "view"), 1, GL_FALSE, glm::value_ptr(viewMatrix));
	}

	void AssignProjectionMatrix(glm::mat4 projectionMatrix)
	{
		glUniformMatrix4fv(glGetUniformLocation(Program, "projection"), 1, GL_FALSE, glm::value_ptr(projectionMatrix));
	}
};

#endif // SHADER_PROGRAM_H
