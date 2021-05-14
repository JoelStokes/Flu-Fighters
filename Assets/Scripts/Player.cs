using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject Projectile;
	public GameObject Camera;
    public GameObject Explosion;

	public GameObject JetFlameLeft;
	public GameObject JetFlameRight;
	public GameObject JetFlameStartLeft;
	public GameObject JetFlameStartRight;

	private int startCounter = 0;
	private int startEnd = 215;
	private bool startDone = false;

	private float moveX;
	private float moveY;
	private float speed = .15f;
	private float scrollSpeed = .04f;   //Changed from original .03
    private int gunLevel = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startCounter > startEnd && !startDone) {	//Intro
			Animator a = GetComponent<Animator> ();
			a.enabled = false;
			startDone = true;
			JetFlameStartLeft.SetActive (true);
			JetFlameStartRight.SetActive (true);
		} else
			startCounter++;

		if (startDone) {	//Normal player logic
			if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
				moveY = speed;
			} else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.W)) {
				moveY = -speed;
			} else
				moveY = 0;

			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
				moveX = -speed;
			} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
				moveX = speed;
			} else
				moveX = 0;

			//Move Player
			if (transform.position.x + moveX < Camera.transform.position.x - 12.2f)
				moveX = 0;
			transform.position = new Vector3 (transform.position.x + moveX + scrollSpeed, 
				transform.position.y + moveY, transform.position.z);

			if (Input.GetKeyDown (KeyCode.Space)) {
                if (gunLevel == 1)  //Basic
                {
                    Instantiate(Projectile, new Vector3(transform.position.x + 1f, transform.position.y, 1), Quaternion.Euler(0, 0, -90));
                }
                else if (gunLevel >= 2) //Spreadshot
                {
                    //SIDE SHOT STRAIGHT
                    /*
                    Instantiate(Projectile, new Vector3(transform.position.x - .4f, transform.position.y - 0.68f, 1), Quaternion.Euler(0, 0, -90));
                    Instantiate(Projectile, new Vector3(transform.position.x - .4f, transform.position.y + 0.68f, 1), Quaternion.Euler(0, 0, -90));
                    */

                    //SIDE SHOT DIAG

                    Instantiate(Projectile, new Vector3(transform.position.x - .35f, transform.position.y - 0.68f, 1), Quaternion.Euler(0, 0, -85));
                    Instantiate(Projectile, new Vector3(transform.position.x - .35f, transform.position.y + 0.68f, 1), Quaternion.Euler(0, 0, -95));
                    

                    //DIAGONAL SHOT FRONT
                    /*
                    Instantiate(Projectile, new Vector3(transform.position.x + 1f, transform.position.y, 1), Quaternion.Euler(0, 0, -70));
                    Instantiate(Projectile, new Vector3(transform.position.x + 1f, transform.position.y, 1), Quaternion.Euler(0, 0, -110));
                    */
                }
			}

			//Fire Animation
			if (JetFlameStartLeft.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime > 1) {
				JetFlameStartLeft.SetActive (false);
				JetFlameStartRight.SetActive (false);
				JetFlameRight.SetActive (true);
				JetFlameLeft.SetActive (true);
			}
		}

		//Move Camera
		Camera.transform.position = new Vector3(Camera.transform.position.x + scrollSpeed, Camera.transform.position.y, Camera.transform.position.z);
	}

	public void Hurt(){		//TO BE REPLACED WITH ACTUAL HURT ROUTINE!
		Die();
	}

	void Die(){
        Instantiate(Explosion, new Vector3(transform.position.x+7.5f, transform.position.y-2, transform.position.z), Quaternion.identity);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Wall" || other.tag == "Untagged" || other.tag == "EnemyProjectile") {
			Hurt ();
        }
        else if (other.tag == "Item")
        {
            gunLevel++;
            Destroy(other.gameObject);
        }
	}
}
