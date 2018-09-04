using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed = 10.0f;
	[SerializeField] private float defaultSpeed;
	[SerializeField] private float jump = 50.0f;
	[SerializeField] private float defaultJump;
	[SerializeField] private float run;

	[SerializeField] private bool jumpDisable;

	Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;
		defaultSpeed = speed;
		defaultJump = jump;
		run =speed * 1.5f;
	}
		
	void FixedUpdate () {

		//Andar
		float moveVert = Input.GetAxis("Vertical") * speed;
		float moveHor = Input.GetAxis("Horizontal") * speed;
		moveVert *= Time.deltaTime;
		moveHor *= Time.deltaTime;
		transform.Translate(moveHor, 0, moveVert);
		//

		//Pular
		if (Input.GetButtonDown ("Jump")) {
			
			rb.AddForce (Vector3.up * jump, ForceMode.Impulse);
			jumpDisable = true;
		}

		if (jumpDisable == true) {
			jump = 0;
		} else {
			jump = defaultJump;
		}
		//

		//Correr
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = run;
		} else {
			speed = defaultSpeed;
		}
		//

		//habilitar o cursor
		if (Input.GetKeyDown (KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;
		//
	}

	void OnCollisionEnter (Collision other){

		if (other.gameObject.tag == "floor")
			jumpDisable = false;

	}
}
