#ifndef SHADER_PROHRAM_H
#define SHADER_PROGRAM_H

#include "utils.h"

#include <string>
#include <iostream>

#include <gl/glew.h>

class ShaderProgram
{
	const char* vertexShaderSource;
	const char* fragmentShaderSource;
	GLuint Program;
	GLuint vShader, fShader;
	std::vector<const char*> shaderAttributeNames;

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

		for (auto shaderAttributeName : shaderAttributeNames)
		{
			GLuint shaderAttribute = glGetAttribLocation(Program, shaderAttributeName);
			if (shaderAttribute == -1)
			{
				std::cout << "could not bind attrib " << shaderAttributeName << std::endl;
			}
		}

		checkOpenGLerror();
	}
public:
	ShaderProgram(const char* vertexShaderSource, const char* fragmentShaderSource, const std::vector<const char*>& shaderAttributeNames)
		: vertexShaderSource(vertexShaderSource), fragmentShaderSource(fragmentShaderSource), shaderAttributeNames(shaderAttributeNames)
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

	void Delete()
	{
		glDeleteProgram(Program);
	}
};

#endif // SHADER_PROGRAM_H