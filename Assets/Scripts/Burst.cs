using UnityEngine;
using System.Collections;

public class Burst : MonoBehaviour {

	public float direction;	//-1 Left, 0 up, 1 Right

	private Rigidbody2D rigi;
	private float randomX;
	private float randomY;
	private float randomSpin;

	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		randomSpin = Random.Range (-20, 20);
		randomX = Random.Range (1, 10);
		randomY = Random.Range (5, 13);
		rigi.velocity = new Vector2 (randomX*direction, randomY);
	}

	void Update(){
		//rigi.velocity = new Vector2 (randomX, randomY);
		transform.Rotate(0,0,randomSpin);

		if (transform.position.y < -20)
			Destroy (gameObject);
	}
}
