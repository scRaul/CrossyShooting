using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   // public float damage = 100f;
    float speed = 15f;

    void Move()
    {

        transform.Translate(0, speed * Time.deltaTime, 0, Space.Self);

    }
    private void Update()
    {
        Move();
    }
}
/*
Class Projectile
    Data Members:

        float damage;
        float speed;

     Functions:

        Move();



 
 */