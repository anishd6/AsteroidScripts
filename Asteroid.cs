using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public bool ast1, ast2, ast3, ast4;
    public GameObject BA1, BA2, BA3, BA4;
    public static float scoreMultiplier = 1.0f; // set default point multiplier
    private float rotationSpeed;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 direction;
    private PlayerMovement ship;
    private float shift;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GameObject.FindObjectOfType<PlayerMovement>(); //find the object in my playermovement script 
        direction = ship.transform.position - transform.position; // pos of asteroid - pos of spaceship using (x,y) - (x,y) to get final xy val, will move in both xy simeltaneously 

        rotationSpeed = Random.Range(-25, 25); //rand rotation speed, varying CW AND a-cw
        shift = Random.Range(-7, 7);
        rb.AddForce(new Vector2(direction.x + shift, direction.y + shift) * speed); //using shift val for x and y for different directions using random range for somewhat random dirs

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime); //change rotationvalue so rotation happens
        CheckPosition();
    }
    public void CheckPosition() 
    {
        if (transform.position.x > 15 || transform.position.x < -15)
        {
            Destroy(gameObject);
        }
        if (transform.position.y > 9 || transform.position.y<-9)
        {
            Destroy(gameObject);   //self explanitory destroy game object system based on transform pos range

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "PlayerBullet(Clone)")
        {
            Destroy(collision.gameObject); //on collision of the 2 objs we destroy both (maybe upgrade where bullet keeps going instead of getting destroyed)

            if (ast1)
            {
                ScoreManager.score += 100 * scoreMultiplier;
                Instantiate(BA1, transform.position, Quaternion.identity); //onkill callBA1, which is my prefab of the destroy
            }
            else if(ast2)
            {
                ScoreManager.score += 50 * scoreMultiplier;
                Instantiate(BA2, transform.position, Quaternion.identity);  //check and set pos and rot at obj
            }

            else if (ast3)
            {
                ScoreManager.score += 75 * scoreMultiplier;
                Instantiate(BA3, transform.position, Quaternion.identity);
            }

            else if (ast4)
            {
                ScoreManager.score += 65 * scoreMultiplier;
                Instantiate(BA4, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
