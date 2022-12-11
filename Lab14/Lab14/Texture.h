#ifndef TEXTURE_H
#define TEXTURE_H

#include "ShaderProgram.h"

#include <iostream>

#include <gl/glew.h>
#include <SOIL/SOIL.h>

class Texture
{
	GLuint textureId;
	GLuint textureUnitNumber;
	unsigned char* image;
public:
	Texture(GLuint textureUnitNumber, const char* textureFilename) 
		: textureUnitNumber(textureUnitNumber) 
	{
		int imageWidth, imageHeight;
		image = SOIL_load_image(textureFilename, &imageWidth, &imageHeight, 0, SOIL_LOAD_RGB);
        glActiveTexture(GL_TEXTURE0 + textureUnitNumber);
        glGenTextures(1, &textureId);
        Bind();

        if (image)
        {
            glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, imageWidth, imageHeight, 0, GL_RGBA, GL_UNSIGNED_BYTE, image);
            glGenerateMipmap(GL_TEXTURE_2D);
        }
        else
        {
            std::cout << "could not load texture " << textureFilename << std::endl;
        }

        Unbind();
        SOIL_free_image_data(image);
	}

    GLuint GetID()
    {
        return this->textureId;
    }

    void Assign(ShaderProgram& shaderProgram, const char* uniformName)
    {
        shaderProgram.Use();
        glUniform1i(glGetUniformLocation(shaderProgram.GetID(), uniformName), textureUnitNumber);
    }

    void Bind()
    {
        glActiveTexture(GL_TEXTURE0 + textureUnitNumber);
        glBindTexture(GL_TEXTURE_2D, textureId);
    }

    void Unbind()
    {
        glBindTexture(GL_TEXTURE_2D, 0);
    }

    void Delete()
    {
        glDeleteTextures(1, &textureId);
    }
};

#endif // TEXTURE_H
