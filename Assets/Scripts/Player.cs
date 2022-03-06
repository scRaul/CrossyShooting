using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Movement movement;
    Gun gun;

    float mySpeed = 10f;
    [SerializeField] Health myHealth;


    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canMoveBack = true;
    public bool canShoot = true;//while not in cover
    bool alive = true;

    public int score;
    private void Awake()
    {
        score = 0;
        GetComponent<Trigger>().PlayerHitEvent.AddListener(delegate { TakeDamage(); });
        movement = GetComponent<Movement>();
        movement.speed = mySpeed;
        gun = GetComponentInChildren<Gun>();
    }
    public void MoveLeft()
    {
        if(canMoveLeft && alive)
            movement.MoveLeft();
    }
    public void MoveRight()
    {
        if(canMoveRight && alive)
         movement.MoveRight();
    }
    public void MoveFoward()
    {
        if(alive)
            movement.MoveFoward();
    }
    public void MoveBack()
    {
        if(canMoveBack && alive)
            movement.MoveBack();
    }
    public void Shoot()
    {
        if(canShoot && alive)
           gun.Fire();
    }
    public void Reload()
    {
        if(alive)
            gun.Reload();
    }
    public void TakeDamage()
    {

        myHealth.life -= 34;
        if (myHealth.life <= 0)
        {
 
            transform.localScale = new Vector3(.1f, .1f, .1f);
            MoveBack();
            alive = false;
            GetComponentInParent<Game>().Restart();
        }
    }
    public void AddScore()
    { 
        score += 1;
    }
}
/*
 Class Player
    Data Members:
        Movement movement;
        Gun gun;
        float mySpeed;

    Functions:

        MoveLeft();
        MoveRight();
        MoveFoward();
        MoveBack();
        Fire();

 * 
 */
