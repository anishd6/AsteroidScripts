using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool MyEnemy;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private Rigidbody2D rb;
    private float EnemyShootSpeed;
    public float startShootSpeed;
    public GameObject projectile;
    public static float scoreMultiplier = 1.0f; // set default point multiplier

    public Transform Myplayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Myplayer = GameObject.FindGameObjectWithTag("Player").transform; // set player = position to my created tag in unity i put a player tag on my playerSpaceship
        EnemyShootSpeed = startShootSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Myplayer.position) > stoppingDistance) // (enemypos, player pos) if > stopping distance move toward player
        {
            transform.position = Vector2.MoveTowards(transform.position, Myplayer.position, speed * Time.deltaTime); // great distance so run at player using .movetowards to do this
        }
        else if (Vector2.Distance(transform.position, Myplayer.position) < stoppingDistance && Vector2.Distance(transform.position, Myplayer.position) > stoppingDistance)
        {
            transform.position = this.transform.position; //freeze enemy if near player (write statement to back away if time)
        }
        else if (Vector2.Distance(transform.position, Myplayer.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Myplayer.position, -speed * Time.deltaTime); //literally same as movetowards with -speed to move backwards 
        }

        if (EnemyShootSpeed <= 0)  //literally using from player shooting
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            EnemyShootSpeed = startShootSpeed; //capping shootSpam so cant keeep shooting every frame
        }
        else
        {
            EnemyShootSpeed -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D Mycollision)
    {

        if (Mycollision.gameObject.name == "PlayerBullet(Clone)")
        {
            Destroy(Mycollision.gameObject);
            if (MyEnemy)
            {
                ScoreManager.score += 100 * scoreMultiplier;
            }
            Destroy(gameObject);
        }
    }
}

