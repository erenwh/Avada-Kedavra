using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrianGesture : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
		
	}

	public void Fire() {
			var bullet = (GameObject)Instantiate (
				bulletPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
