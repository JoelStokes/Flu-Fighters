using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cold : MonoBehaviour {		//To be made modular to work with all default enemies!

	public int health = 2;

	public GameObject FaceObject;
	public GameObject Body;
	public GameObject Explosion;

    public enum MoveType { None, Horizontal, Vertical, Homing }
    public MoveType moveType;

    public AnimationCurve bobCurve;

	public bool changingFace = false;
	public float moveSpeed = 0;	//How fast move takes place
	public float moveDistance = 0; //For up and down

	public Sprite SadFace;
	public Sprite DyingFace;

	private bool injured = false;
	private float colorChange = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Die ();
		}

		if (injured) {	//Animation of being shot, color change
			Body.GetComponent<SpriteRenderer> ().color = new Vector4 (1,1,1,Body.GetComponent<SpriteRenderer> ().color.a + colorChange);
			if (Body.GetComponent<SpriteRenderer> ().color.a == 1)
				injured = false;
		}

		if (moveType == MoveType.Horizontal) {
			transform.position = new Vector3 (transform.position.x - moveSpeed, transform.position.y + bobCurve.Evaluate((Time.time % bobCurve.length)), transform.position.z);
		}

		if (moveType == MoveType.Vertical) {
            transform.position = new Vector3(transform.position.x + bobCurve.Evaluate((Time.time % bobCurve.length)), transform.position.y - moveSpeed, transform.position.z);
		}

        if (moveType == MoveType.Homing) {
            //TO DO!!!!
        }
	}

	public void Hurt(){
		health--;
		injured = true;
		if (changingFace) {
			if (health > 3 && health < 9)
				FaceObject.GetComponent<SpriteRenderer> ().sprite = SadFace;
			else if (health < 9)
				FaceObject.GetComponent<SpriteRenderer> ().sprite = DyingFace;
		}
		Body.GetComponent<SpriteRenderer> ().color = new Vector4(1,1,1,.1f);
	}

	void Die(){
		Instantiate (Explosion, transform.position, Quaternion.identity);
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
