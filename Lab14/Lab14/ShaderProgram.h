#ifndef SHADER_PROHRAM_H
#define SHADER_PROGRAM_H

#include <string>

#include <gl/glew.h>

class ShaderProgram
{
	const char* vertexShaderSource;
	const char* fragmentShaderSource;
	GLuint programId;
public:
	ShaderProgram(const char* vertexShaderSource, const char* fragmentShaderSource) 
		: vertexShaderSource(vertexShaderSource), fragmentShaderSource(fragmentShaderSource)
	{
	}

	static ShaderProgram CreateFromGLSLSourceCodeFiles(const std::string& vertexShaderSourceFilename, const std::string fragmentShaderSourceFilename)
	{

	}
};

#endif // SHADER_PROGRAM_H