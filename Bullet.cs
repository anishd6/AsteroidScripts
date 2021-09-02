using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400f*(-1)); //bullet moves +y, muist make go -y dir, 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillBullet()
    {
        Destroy(gameObject, 2f); //used to destroy bullets from scene to not clog, giving 2s timer
    }
}
