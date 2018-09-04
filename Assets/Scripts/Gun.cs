using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 10.0f;
	public float range = 100.0f;
	public float fireRate = 15f;
	public float impactForce = 5.0f;

	//public ParticleSystem muzzleFlash;
	//public GameObject impactEffect;

	private float nextTimeToFire = 0f;

	public Camera cam;

	void Awake(){

		cam = FindObjectOfType<Camera> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") && Time.time >= nextTimeToFire) {

			nextTimeToFire = Time.time + 1f / fireRate;
			Shoot ();
		}
	}

	void Shoot(){

		//muzzleFlash.Play ();

		RaycastHit hit;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {

			print (hit.transform.name);

			DamageToTake damageToTake = hit.transform.GetComponent<DamageToTake> ();

			if (damageToTake != null) {

				damageToTake.takeDamage (damage);
				print (damageToTake.health);
			}

			if (hit.rigidbody != null) {

				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}

			/*GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f);*/
		}
	}
}
