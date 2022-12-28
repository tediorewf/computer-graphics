#ifndef ENTITY_H
#define ENTITY_H

#include <GL/glew.h>
#include <glm/vec3.hpp>

class Entity
{
protected:
	glm::vec3 position;
	GLfloat rotationX, rotationY, rotationZ;
public:
	Entity(glm::vec3 position, GLfloat rotationX, GLfloat rotationY, GLfloat rotationZ)
		: position(position), 
		rotationX(rotationX), rotationY(rotationY), rotationZ(rotationZ)
	{
	}

	void increaseRotation(GLfloat offsetX, GLfloat offsetY, GLfloat offsetZ)
	{
		rotationX += offsetX;
		rotationY += offsetY;
		rotationZ += offsetZ;
	}

	void increasePosition(GLfloat offsetX, GLfloat offsetY, GLfloat offsetZ)
	{
		position += glm::vec3(offsetX, offsetY, offsetZ);
	}

	glm::vec3 getPosition() const
	{
		return position;
	}

	GLfloat getRotationX() const
	{
		return rotationX;
	}

	GLfloat getRotationY() const
	{
		return rotationY;
	}

	GLfloat getRotationZ() const
	{
		return rotationZ;
	}
};

#endif // !ENTITY_H
