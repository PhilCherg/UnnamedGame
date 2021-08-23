using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public float cameraMoveSpeed = 10f;
	public Transform PlayerCoordinates;
	
		
	void Update()
	{
		Vector3 cameraFollowPosition = PlayerCoordinates.position;
		cameraFollowPosition.z = transform.position.z;

		Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
		float distance = Vector3.Distance(cameraFollowPosition, transform.position);

		if (distance > 0 )
        {
			Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

			float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

			if (distanceAfterMoving > distance)
            {
				newCameraPosition = cameraFollowPosition;
            }

			transform.position = newCameraPosition;
        }

	}
}