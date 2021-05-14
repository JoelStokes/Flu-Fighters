using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shoots out bullets that aim towards the player's positions only when in range

public class BacterioShooter : MonoBehaviour
{
    public GameObject Bullet;

    public float bulletSpeed = 1f;
    public float shootLim = 1;
    
    private float timer = 0;
    private bool inRange = false;
    private GameObject Player;

    void Update()
    {
        if (Player) //Check to make sure Player has not died
        {
            timer += Time.deltaTime;

            if (timer > shootLim && inRange)
            {
                timer = 0;
                GameObject NewBullet = (GameObject)Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
                NewBullet.GetComponent<Rigidbody2D>().AddForce((Player.transform.position - transform.position).normalized * bulletSpeed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject;
            inRange = true;
        }
    }
}
