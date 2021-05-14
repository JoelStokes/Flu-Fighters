using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hurt(){

	}

	void Die(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Projectile") {
			Hurt ();
			Destroy (other.gameObject);
		} else if (other.tag == "Player") {
			other.GetComponent<Player> ().Hurt ();
		}
	}
}
