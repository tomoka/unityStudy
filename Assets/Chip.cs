﻿using UnityEngine;
using System.Collections;

public class Chip: MonoBehaviour {

	public float forceY;
	public float clampVelocity;
	private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// 速度制限を設ける
		this.rigidbody.velocity = Vector3.ClampMagnitude(this.rigidbody.velocity, clampVelocity);

		if (Input.GetKeyDown("space")) {
			this.MoveUp();
		}
	}

	void MoveUp() {
		// 速度をゼロにする
		this.rigidbody.velocity = Vector3.zero;

		// 上方向(Y)に力を加える
		this.rigidbody.AddForce(new Vector2(0, forceY));
	}
}
