using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidneyStone : MonoBehaviour
{
    private int health = 7;
    public GameObject Item;
    public GameObject[] Pieces;
    public Sprite[] HurtPhases;

    void Die()
    {
        foreach (GameObject i in Pieces)
        {
            Instantiate(i, transform.position, Quaternion.identity);
        }
        Instantiate(Item, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Hurt()
    {
        Instantiate(Pieces[Random.Range(0, Pieces.Length)], transform.position, Quaternion.identity);
        health--;
        if (health <= 0)
        {
            Die();
        }
        else if (health % 2 == 0)   //For each even number, show new broken kidney stone sprite
        {
            GetComponent<SpriteRenderer>().sprite = HurtPhases[(health/2) - 1];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Hurt();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player")
        {
            other.GetComponent<Player>().Hurt();
        }
    }
}
