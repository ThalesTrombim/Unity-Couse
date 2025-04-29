using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Player player;
	private Animator animator;

	void Start()
	{
		player = GetComponent<Player>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		OnMove();
		onRun();
	}

	#region Movement

	void OnMove()
	{
		if (player.direction.sqrMagnitude > 0)
		{
			animator.SetInteger("transition", 1);
		}
		else
		{
			animator.SetInteger("transition", 0);
		}

		if (player.direction.x < 0)
		{
			transform.eulerAngles = new Vector2(0, 180);
		}

		if (player.direction.x > 0)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}
	}

	void onRun()
	{
		Debug.Log("testing");
		if (player.isRunning)
		{
			animator.SetInteger("transition", 2);
		}
	}

	#endregion
}
