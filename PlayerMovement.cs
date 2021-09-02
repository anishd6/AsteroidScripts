using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCam;
    public float ShipSpeed;
    private Rigidbody2D rbod;
    public JoyStick MoveJoystick;
    public float rotationSpeed;
    public JoyStick ShootJoystick;
    public GameObject bullet;
    public bool CanShoot;
    public static float ShootRate = 0.7f; // Set initial rate 
    private float NextShoot;
    public GameObject engine1, engine2;
    private ParticleSystem p1, p2;
    public int maxHealth = 100;
    public static int currentHealth;
    public HealthBar healthBar;
    void Start() //called 1frame before update methd
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        p1 = engine1.GetComponent<ParticleSystem>();
        p2 = engine2.GetComponent<ParticleSystem>(); //make particle animation play on gamestart (must fix)
        p1.Stop();
        p2.Stop(); //make it stop

        rbod = GetComponent<Rigidbody2D>(); // Assign our 2drigidbody from unity
        mainCam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.GetMouseButtonDown(0))
        {
            p1.Play();
            p2.Play();  //onpress engine play particle effects of engine
        }

        if (Input.GetMouseButtonUp(0))
        {
            p1.Stop();
            p2.Stop();  //onlift stop
        }

        checkPostition();
        if(Input.GetMouseButton(0) && CanShoot)
        {
           
            if(NextShoot> 0)
            {
                NextShoot -= Time.deltaTime; // depreciating timer for Nextshoot
            }
            if (NextShoot <= 0 ) //can only call this relative to deltatime above
            {
                Shoot();
            }
            
        }
        MoveShip();
        Rotation();
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0){
            SceneManager.LoadScene("AsteroidArcadeMainMenu");
        }
    }

    void MoveShip()   //(x,y) = vector2 
    {
        //Vector2 MyInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   KEYBOARD USE
        rbod.AddForce(MoveJoystick.InputDir * ShipSpeed);


    }

    void Rotation()
    {
        float angle = Mathf.Atan2(ShootJoystick.InputDir.y, ShootJoystick.InputDir.x)*Mathf.Rad2Deg+90;  //refine knowledge here !@!@!@@ t#3
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
    void Shoot()
    {
        NextShoot = ShootRate;
        GameObject bulletClone = Instantiate(bullet, new Vector2(bullet.transform.position.x, bullet.transform.position.y), transform.rotation);
        bulletClone.SetActive(true);
        //instantiate makes clone, methodology here is to make a clone of the "real" bullet and shoot the fake
        bulletClone.GetComponent<Bullet>().KillBullet(); //getting script and killing bullet from scene
    }

    private void OnCollisionEnter2D(Collision2D Mycollision)
    {

        if (Mycollision.gameObject.name == "Ast1(Clone)")
        {
            Debug.Log("Win1");
            TakeDamage(5);
        }
        if (Mycollision.gameObject.name == "Ast2(Clone)")
        {
            Debug.Log("Win2");
            TakeDamage(10);
        }
        if (Mycollision.gameObject.name == "Ast3(Clone)")
        {
            Debug.Log("Win3");
            TakeDamage(15);
        }

        if (Mycollision.gameObject.name == "Ast4(Clone)")
        {
            Debug.Log("Win4");
            TakeDamage(20);
        }
        if (Mycollision.gameObject.name == "EnemyProjectile(Clone)")
        {
            Debug.Log("Win4");
            TakeDamage(10);
        }
    }

    void checkPostition()
    {
        float screenWidth = mainCam.orthographicSize * 2*mainCam.aspect;
        float screenHeight = mainCam.orthographicSize * 2; //x2 because orthographic size is /2

        float rightEdge = screenWidth / 2;

        float leftEdge = rightEdge * -1; //invert

        float topEdge = screenHeight / 2;
        float bottomEdge = topEdge * -1;

        if(transform.position.x>rightEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }
        if(transform.position.x<leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y); //if x>leftEdge then move right
        }

        if (transform.position.y> topEdge)
        {
            transform.position = new Vector2(transform.position.x, bottomEdge);
        }

        if (transform.position.y < bottomEdge)
        {
            transform.position = new Vector2(transform.position.x, topEdge);
        }
    }
}
