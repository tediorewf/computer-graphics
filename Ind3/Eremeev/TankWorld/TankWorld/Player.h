#ifndef PLAYER_H
#define PLAYER_H

#include "Entity.h"

#include <GL/glew.h>
#include <glm/vec3.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <SFML/Window.hpp>

class Player : public Entity
{
	const GLfloat kRunSpeed, kTurnSpeed;

	glm::vec3 spotLightPosition, spotLightTarget;
	GLfloat currentRunSpeed, currentTurnSpeed;

	void updateSpeed(const sf::Event& e)
	{
		if (e.key.code == sf::Keyboard::W)
		{
			currentRunSpeed = kRunSpeed;
		}
		else if (e.key.code == sf::Keyboard::S)
		{
			currentRunSpeed = -kRunSpeed;
		}
		else
		{
			currentRunSpeed = 0.0f;
		}

		if (e.key.code == sf::Keyboard::A)
		{
			currentTurnSpeed = kTurnSpeed;
		}
		else if (e.key.code == sf::Keyboard::D)
		{
			currentTurnSpeed = -kTurnSpeed;
		}
		else
		{
			currentTurnSpeed = 0.0f;
		}
	}

	void increaseSpotLightTarget(GLfloat offsetX, GLfloat offsetY, GLfloat offsetZ)
	{
		spotLightTarget += glm::vec3(offsetX, offsetY, offsetZ);
	}

	void increaseSpotLightPosition(GLfloat offsetX, GLfloat offsetY, GLfloat offsetZ)
	{
		spotLightPosition += glm::vec3(offsetX, offsetY, offsetZ);
	}
public:
	Player(glm::vec3 position, glm::vec3 spotLightPosition, glm::vec3 spotLightTarget, GLfloat rotationY, GLfloat kRunSpeed, GLfloat kTurnSpeed)
		: Entity(position, 0.0f, rotationY, 0.0f),
		spotLightPosition(spotLightPosition), spotLightTarget(spotLightTarget),
		kRunSpeed(kRunSpeed), kTurnSpeed(kTurnSpeed), 
		currentRunSpeed(0.0f), currentTurnSpeed(0.0f)
	{
	}

	glm::vec3 getSpotLightPosition() const
	{
		return spotLightPosition;
	}

	glm::vec3 getSpotLightDirection() const
	{
		auto spotLightDirection = spotLightTarget - spotLightPosition;
		return spotLightDirection;
	}

	void move(const sf::Event& e, GLfloat framesRenderTimeDelta)
	{
		updateSpeed(e);

		increaseRotation(0.0f, currentTurnSpeed * framesRenderTimeDelta, 0.0f);

		GLfloat runDistance = currentRunSpeed * framesRenderTimeDelta;
		GLfloat radiansRotationY = glm::radians(rotationY);
		GLfloat runOffsetX = runDistance * static_cast<GLfloat>(sin(radiansRotationY));
		GLfloat runOffsetZ = runDistance * static_cast<GLfloat>(cos(radiansRotationY));

		increasePosition(runOffsetX, 0.0f, runOffsetZ);
		increaseSpotLightTarget(runOffsetX, 0.0f, runOffsetZ);
		increaseSpotLightPosition(runOffsetX, 0.0f, runOffsetZ);
	}
};

#endif // !PLAYER_H
