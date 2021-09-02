using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Transform player;
    private Vector2 target;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //once again find transform of object player

        target = new Vector2(player.position.x, player.position.y); //set target to player xy coords
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //move the bullet towards

        void onCollisionEnter2D(Collider2D hit)
        {
            if (hit.gameObject.name == "Player") //using unity tags for colision
            {
                Debug.Log("Player Hit ");
                DestroyProjectile();

            }
        }


        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Debug.Log("reached final");
            DestroyProjectile();
        }

       


        
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
