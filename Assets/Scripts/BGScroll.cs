using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

	public float scrollSpeed;
	public float startX;
	public GameObject Camera;

	void Start(){
		startX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (startX + Camera.transform.position.x*scrollSpeed, transform.position.y, transform.position.z);
	}
}
