﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	
	public Transform target;
	public Transform initialPosition;
	public GameObject player;
	public float speed = 0.15f;
	public float maxDistance = 10f;
	public float minDistance = 5f;

	private Vector3 start, end, actualDistance;
	private float actualMagnitude;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();

		if (target != null) {
			target.parent = null;
			start = initialPosition.position;
			end = target.position;
		}
	}

	void FixedUpdate() {

		actualDistance = transform.position - player.transform.position;
		actualMagnitude = actualDistance.magnitude;
		float fixedSpeed = speed * Time.deltaTime;

		if (actualMagnitude < maxDistance && actualMagnitude > minDistance) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, fixedSpeed);
		}else if(actualMagnitude < maxDistance && actualMagnitude <= minDistance){
			fixedSpeed = 0f;
		}else {
			if (target != null) {
				transform.position = Vector3.MoveTowards (transform.position, target.position, fixedSpeed);
			}

			if (transform.position == target.position) {
				if (target.position == start) {
					target.position = end;
				} else if (target.position == end) {
					target.position = start;
				}
			}
		}
	}
}
