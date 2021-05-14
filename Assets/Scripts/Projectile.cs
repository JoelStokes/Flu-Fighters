using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float moveSpeed = .5f;

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
