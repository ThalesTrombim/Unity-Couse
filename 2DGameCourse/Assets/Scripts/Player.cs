﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float speed;
	private float initialSpeed;
	[SerializeField] private float runSpeed;

	private Rigidbody2D rig;

	private bool _isRunning;
	private Vector2 _direction;
	private bool _isRolling;

	public Vector2 direction
	{
		get { return _direction; }
		set { _direction = value; }
	}

	public bool isRunning
	{
		get { return _isRunning; }
		set { _isRunning = value; }
	}

	public bool isRolling
	{
		get { return _isRolling; }
		set { _isRolling = value; }
	}

	private void Start()
	{
		rig = GetComponent<Rigidbody2D>();
		initialSpeed = speed;
	}

	private void Update()
	{
		onInput();
		onRun();
		OnRolling();
	}

	private void FixedUpdate()
	{
		onInput();
		onMove();
	}

	void onInput()
	{
		_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

	void onMove()
	{
		rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime);
	}

	void onRun()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			speed = runSpeed;
			_isRunning = true;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			speed = initialSpeed;
			_isRunning = false;
		}
	}

	void OnRolling()
	{
		if (Input.GetMouseButtonDown(1))
		{
			_isRolling = true;
		}

		if (Input.GetMouseButtonUp(1))
		{
			_isRolling = false;
		}
	}
}
