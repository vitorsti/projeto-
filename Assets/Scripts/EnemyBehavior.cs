using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public float speed = 10f;
	public Transform target;
	public GameObject gb;

	Rigidbody rb;

	void Awake(){
		
		rb = GetComponent<Rigidbody> ();
		gb = GameObject.FindGameObjectWithTag ("Player");
		target = gb.transform;
	} 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (target);
		transform.position += transform.forward * speed * Time.deltaTime;
		//rb.AddForce (transform.forward * speed);

	}
}
