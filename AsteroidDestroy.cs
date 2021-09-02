﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    private Rigidbody2D[] rbs;
    private float Torque, DirX, DirY;
    private float shift;

 
    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody2D>();

        foreach (Rigidbody2D rb in rbs)
        {
            Torque = Random.Range(-100f, 100f); //similar to before with rotation
            DirX = Random.Range(-100f, 100f);
            DirY = Random.Range(-100f, 100f);
            rb.AddTorque(Torque);
            rb.AddForce(new Vector2(DirX, DirY));

        }
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
