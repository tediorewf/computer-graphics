#ifndef CAMERA_H
#define CAMERA_H

#include "Player.h"

#include <GL/glew.h>
#include <glm/vec3.hpp>
#include <glm/gtx/rotate_vector.hpp>
#include <glm/gtx/vector_angle.hpp>
#include <glm/mat4x4.hpp>
#include <glm/gtc/matrix_transform.hpp>

class Camera
{
	glm::vec3 position, up, spotLightTarget, worldUp, right;
	GLfloat pitch, distanceToPlayer, angleAroundPlayer;
	Player player;
public:
	Camera(const Player &player, GLfloat pitch, GLfloat distanceToPlayer, glm::vec3 worldUp, GLfloat angleAroundPlayer)
		: player(player), pitch(pitch), up(worldUp), worldUp(worldUp), distanceToPlayer(distanceToPlayer), angleAroundPlayer(angleAroundPlayer)
	{
		updateVectors();
	}

	void setPitch(GLfloat pitch)
	{
		this->pitch = pitch;
	}

	void setDistanceToPlayer(GLfloat distanceToPlayer)
	{
		this->distanceToPlayer = distanceToPlayer;
	}

	void setAngleAroundPlayer(GLfloat angleAroundPlayer)
	{
		this->angleAroundPlayer = angleAroundPlayer;
	}

	const Player& getPlayer() const
	{
		return player;
	}

	glm::vec3 getPosition() const
	{
		return position;
	}

	glm::vec3 getFront() const
	{
		return spotLightTarget;
	}

	void move(const sf::Event& e, GLfloat framesRenderTimeDelta)
	{
		player.move(e, framesRenderTimeDelta);
		updateVectors();
	}

	void updateVectors()
	{
		GLfloat radiansPitch = glm::radians(pitch);
		GLfloat sinPitch = static_cast<GLfloat>(sin(radiansPitch));
		GLfloat cosPitch = static_cast<GLfloat>(cos(radiansPitch));

		GLfloat horizontalDistance = distanceToPlayer * cosPitch;
		GLfloat verticalDistance = distanceToPlayer * sinPitch;

		GLfloat playerRotation = player.getRotationY();
		GLfloat radiansPlayerRotation = glm::radians(playerRotation);
		GLfloat radiansAngleAroundPlayer = glm::radians(angleAroundPlayer);
		GLfloat offsetX = horizontalDistance * static_cast<GLfloat>(sin(radiansPlayerRotation + radiansAngleAroundPlayer));
		GLfloat offsetZ = horizontalDistance * static_cast<GLfloat>(cos(radiansPlayerRotation + radiansAngleAroundPlayer));

		auto playerPosition = player.getPosition();

		position.x = playerPosition.x - offsetX;
		position.y = playerPosition.y + verticalDistance;
		position.z = playerPosition.z - offsetZ;

		GLfloat yaw = player.getRotationY() + angleAroundPlayer;
		GLfloat radiansYaw = glm::radians(yaw);
		spotLightTarget = glm::normalize(
			glm::vec3(
				sin(radiansYaw) * cosPitch,
				sinPitch,
				cos(radiansYaw) * cosPitch
			)
		);
		right = glm::normalize(glm::cross(spotLightTarget, worldUp));
		up = glm::normalize(glm::cross(right, spotLightTarget));
	}

	glm::mat4 getViewMatrix() const 
	{
		return glm::lookAt(position, position + spotLightTarget, up);
	}
};

#endif // !CAMERA_H
