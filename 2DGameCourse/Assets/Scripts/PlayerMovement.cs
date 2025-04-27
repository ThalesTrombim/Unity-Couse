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

}
