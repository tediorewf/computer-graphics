#ifndef CAMERA_H
#define CAMERA_H

#include <GL/glew.h>
#include <glm/vec3.hpp>
#include <glm/gtx/rotate_vector.hpp>
#include <glm/gtx/vector_angle.hpp>
#include <glm/mat4x4.hpp>
#include <glm/gtc/matrix_transform.hpp>

class Camera
{
	glm::vec3 position, up, front;
	GLfloat pitch, yaw, speed, sensitivity;

	bool wasNotMovedBefore;
	GLfloat previousX, previousY;

	void setFront()
	{
		GLfloat cosPitch = cos(glm::radians(pitch));
		auto cameraFront = 
		front = glm::normalize(
			glm::vec3(
				cos(glm::radians(yaw)) * cosPitch, 
			    sin(glm::radians(pitch)), 
			    sin(glm::radians(yaw)) * cos(glm::radians(pitch))
			)
		);
	}
public:
	Camera(glm::vec3 position, GLfloat pitch, GLfloat yaw, GLfloat speed = 5.0f, GLfloat sensitivity = 1.0f)
		: position(position), up(glm::vec3(0.0f, 0.0f, 1.0f)), pitch(pitch), yaw(yaw), speed(speed), sensitivity(sensitivity), wasNotMovedBefore(true)
	{
		setFront();
	}

	glm::vec3 getPosition() const
	{
		return position;
	}

	glm::vec3 getFront() const
	{
		return front;
	}

	void moveForward() 
	{
		position += front * speed;
	}

	void moveBackward()
	{
		position -= front * speed;
	}

	void moveRight()
	{
		auto right = glm::normalize(glm::cross(front, up));
		position += right * speed;
	}

	void moveLeft()
	{
		auto right = glm::normalize(glm::cross(front, up));
		position -= right * speed;
	}

	void rotateMouse(GLfloat x, GLfloat y)
	{
		if (wasNotMovedBefore)
		{
			previousX = x;
			previousY = y;
			wasNotMovedBefore = false;
		}

		GLfloat xOffset = previousX - x;
		GLfloat yOffset = previousY - y;
		previousX = x;
		previousY = y;

		xOffset *= sensitivity;
		yOffset *= sensitivity;

		yaw += yOffset;
		pitch += xOffset;

		setFront();
	}

	glm::mat4 getViewMatrix() const 
	{
		return glm::lookAt(position, position + front, up);
	}
};

#endif // !CAMERA_H
