using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ShootUp : MonoBehaviour
{
    public float fastRate = 0.1f; // Upgraded fire rate value
    public float normalRate = 0.7f; // Default fire rate value
    public float length = 10f; // How long powerup lasts

    private void OnCollisionEnter2D(Collision2D collision) // When collision with powerup occurs
    {
        if (collision.gameObject.name == "Player") // if the colliding object is tagged "Player"
        {
            GetComponent<SpriteRenderer>().enabled = false;        // find and disable renderer to make sprite invisible
            GetComponent<PolygonCollider2D>().enabled = false;     // find and disable collider to prevent any collisions after the first one

            StartCoroutine(Pickup());  // Starts the IEnumerator Pickup method
        }
    }

    IEnumerator Pickup()   // IEnumerator allows you to temporarily stop processing the code, needed for WaitForSeconds function
    {
        PlayerMovement.ShootRate = fastRate; // changes the fire rate to the upgraded value

        yield return new WaitForSeconds(length); // wait for a specified "length" of time (seconds)

        PlayerMovement.ShootRate = normalRate; // changes the score multiplier back to the default value

        Destroy(GameObject.FindWithTag("PowerUp")); // destroys the object so that it exits the scene
    }

}
