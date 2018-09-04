﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToTake : MonoBehaviour {

	public float health = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage (float damageToTake){

		health -= damageToTake;

		if (health <= 0) {

			Destroy (this.gameObject);
		}
	}
}
