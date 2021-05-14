using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {

	public int countLimit = 0;
	public float fadeSpeed = 0;

	private int counter = 0;
	
	// Update is called once per frame
	void Update () {
		if (counter > countLimit) {
			GetComponent<Text> ().color = new Vector4 (1,1,1,GetComponent<Text> ().color.a - fadeSpeed);
		} else
			counter++;

		if (GetComponent<Text> ().color.a == 0)
			Destroy (gameObject);
	}
}
