﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 10;
	private BoxCollider2D playerCollider;
	private Rigidbody2D rb;

	public float dashMovement = 10000;
	public float dashRate = 1;
	private float timeToDash = 0;

	void Awake(){
		
		rb = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<BoxCollider2D> ();
		if (playerCollider == null) {
			Debug.LogError ("There is no BoxCollider Attached to the player!");
		}
		if (rb == null) {
			Debug.LogError ("There is no RigidBody Attached to the player!");
		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb.velocity = movement * speed;

		if (Input.GetButtonDown ("Jump") && Time.time > timeToDash) {
			timeToDash = Time.time + 1 / dashRate;
			rb.AddForce (movement * dashMovement);
		}

	}
}
