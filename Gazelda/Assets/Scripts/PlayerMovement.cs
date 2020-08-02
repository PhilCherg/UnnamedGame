using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;
    public Animator animator;

    private float animTimerThreshold = 0.2f;
    private float animTimer = 0f;
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
            animTimer = 0;
        } else if ((moveDirection.x == 1 || moveDirection.x == -1) && (animTimer > animTimerThreshold))
        {
			animator.SetFloat("lastMoveX", moveDirection.x);
			animator.SetFloat("lastMoveY", 0);
            animTimer = 0;
		} else if ((moveDirection.y == 1 || moveDirection.y == -1) && (animTimer > animTimerThreshold))
		{
			animator.SetFloat("lastMoveX", 0);
			animator.SetFloat("lastMoveY", moveDirection.y);
            animTimer = 0;
        }else
        {
            animTimer += Time.fixedDeltaTime;
        }

    }

	private void FixedUpdate()
	{
		transform.position += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
	}
}
