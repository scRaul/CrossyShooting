using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Movement movement;
    SoundManager soundFx;
    Gun gun;
    bool canShoot = true;
    Health myHealth;
    float speed = 6f;
    


    public int type = 1;
    GameObject target = null;

    public UnityEvent DeathEvent;

    private void Awake()
    {
        soundFx = GetComponent<SoundManager>();
        myHealth = GetComponentInChildren<Health>();
        movement = GetComponent<Movement>();
        movement.speed = speed;
        gun = GetComponentInChildren<Gun>();
    }
    public void MoveLeft()
    {
        movement.MoveLeft();
    }
    public void MoveRight()
    {
        movement.MoveRight();
    }
    public void MoveFoward()
    {
        movement.MoveFoward();
    }
    public void MoveBack()
    {
        movement.MoveBack();
    }
    IEnumerator Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            gun.Fire();
            yield return new WaitForSeconds(1f);
            canShoot = true;
        }
    }
    public int TakeDamage()
    {
        soundFx.PlaySound("hit");
       
        myHealth.life -= 34;
        if (myHealth.life <= 0)
        {
            DeathEvent.Invoke();
            
            Destroy(gameObject);
            return 1;
        }
        return 0;
    }

    public void SetTarget(GameObject player)
    {
        target = player;

    }

    public void ShootTarget()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
    
        if (Physics.Raycast(gun.transform.position, fwd, out hit))
        {
            Debug.DrawRay(gun.transform.position, fwd * 10, Color.blue);
            if (hit.transform.CompareTag("Player"))
                StartCoroutine(Shoot());
        }
        Debug.DrawRay(gun.transform.position, fwd * 10, Color.blue);

    }
 
    void MoveWithTarget()
    {
        if (target != null)
        {
            float range = 1.55f;
            float horizontal = target.transform.position.x - transform.position.x;
            float vertical = target.transform.position.z - transform.position.z;
          
            if(Mathf.Abs(vertical) > Mathf.Abs(horizontal))
            {
                if (vertical < -range)
                {
                    MoveBack();
                }
                else if (vertical > range)
                    MoveFoward();
            }
            else
            {
                if (horizontal < -range)
                    MoveLeft();
                else if(horizontal  > range)
                {
                    MoveRight();
                }
            }
    
       
        
        }
    }
    int changeDirections = 1;
    void PaceLeftandRight()
    {
        if (changeDirections == 1)
            MoveLeft();
        else
            MoveRight();

    }
    void PaceBackandFoward()
    {
        if (changeDirections == 1)
            MoveBack();
        else
            MoveFoward();

    }

    private void FixedUpdate()
    {
        if (gun.magSize <= 0)
            gun.Reload();
      
    }
    private void Update()
    {
        if (target != null)
        {
            RaycastHit hit_target;
            Vector3 dirTar = Vector3.Normalize(target.transform.position - this.transform.position);
            if (Physics.Raycast(this.transform.position, dirTar, out hit_target))
            {

                Debug.DrawRay(this.transform.position, dirTar * hit_target.distance, Color.yellow);
                if (hit_target.transform.CompareTag("Player"))
                {
                    MoveWithTarget();
                    ShootTarget();
                }
                else
                    target = null;
            }
            else
                target = null;
        }
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(this.transform.position, fwd, out hit))
        {
            if (hit.transform.CompareTag("Obsticle") && hit.distance < 1)
            {
                changeDirections = 3 - changeDirections;

            }
        }
        if (target == null)
        {
            if (type == 1)
                PaceLeftandRight();
            if (type == 2)
                PaceBackandFoward();
        }

    }
}
/*
 class Enemy
    Data members:
        Gun gun;
        Movement movent;
        Health myHealth;
        UnityEvent DeathEvent;
        GameObject target = null;

 Functions:

        MoveLeft();
        MoveRight();
        MoveFoward();
        MoveBack();
        TakeDamage();
        SetTarget();

        ShootTarget();
        SetTarget();
        MoveWithTarget();

        PaceLeftandRight();
        PaceBackandfoward();
        


 */