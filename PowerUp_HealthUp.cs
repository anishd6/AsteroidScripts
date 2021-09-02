using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_HealthUp : MonoBehaviour
{
    public int addHealth = 50; // Upgraded fire rate value
    private int healthCon;
    private HealthBar health;


    private void OnCollisionEnter2D(Collision2D collision) // When collision with powerup occurs
    {
        if (collision.gameObject.name == "Player") // if the colliding object is tagged "Player"
        {
            GetComponent<SpriteRenderer>().enabled = false;        // find and disable renderer to make sprite invisible
            GetComponent<PolygonCollider2D>().enabled = false;     // find and disable collider to prevent any collisions after the first one

            Pickup();  // Starts the Pickup method
        }
    }

    void Pickup()
    {
        PlayerMovement.currentHealth += addHealth; // gives the player health

        Destroy(GameObject.FindWithTag("PowerUp")); // destroys the object so that it exits the scene
    }

}