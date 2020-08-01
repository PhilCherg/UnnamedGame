using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Animator animator;

	private Vector3 moveDirection;
	private bool isIdle;
	private enum idleDirection
	{
		north, northWest, west, southWest, south, southEast, east, northEast
	}
	idleDirection direction = idleDirection.south;

	void Update()
    {
		moveDirection.x = Input.GetAxisRaw("Horizontal");
		moveDirection.y = Input.GetAxisRaw("Vertical");

		animator.SetFloat("moveX", moveDirection.x);
		animator.SetFloat("moveY", moveDirection.y);
		animator.SetFloat("magnitude", moveDirection.magnitude);

		if ((moveDirection.x == 1 || moveDirection.x == -1) && (moveDirection.y == 1 || moveDirection.y == -1))
		{
			animator.SetFloat("lastMoveX", moveDirection.x);
			animator.SetFloat("lastMoveY", moveDirection.y);
		} else if (moveDirection.x == 1 || moveDirection.x == -1)
		{
			animator.SetFloat("lastMoveX", moveDirection.x);
			animator.SetFloat("lastMoveY", 0);
		} else if (moveDirection.y == 1 || moveDirection.y == -1)
		{
			animator.SetFloat("lastMoveX", 0);
			animator.SetFloat("lastMoveY", moveDirection.y);
		}
    }

	private void FixedUpdate()
	{
		transform.position += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
	}
}
