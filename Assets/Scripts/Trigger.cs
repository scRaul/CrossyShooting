using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent LandTriggerEvent;
    public UnityEvent MotherShipTriggerEvent;
    public UnityEvent PointEvent;
    public UnityEvent PlayerHitEvent;
    private void OnTriggerEnter(Collider other)
    {
        //play ruffle in bushes and set shooting off
        if(this.CompareTag("Player") && other.CompareTag("Obsticle"))
        {
            this.gameObject.GetComponent<SoundManager>().PlaySound("ruffle");
            this.gameObject.GetComponent<Player>().canShoot = false;
        }
        
        //Restrict left and right movement from leaving world borders
        if (other.CompareTag("Player"))
        {
            if (this.name == "LeftBorder")
                other.transform.GetComponent<Player>().canMoveLeft = false;
            if (this.name == "RightBorder")
                other.transform.GetComponent<Player>().canMoveRight = false;
            if (this.name == "BackBorder")
                other.transform.GetComponent<Player>().canMoveBack = false;
        }
      
        //spawn enemies, and destroy spawner
        if (this.CompareTag("MotherShipTrigger"))
        {
            if (other.CompareTag("Player"))
            {
                MotherShipTriggerEvent.Invoke();
                Destroy(this.gameObject);
            }
        }
        //shift land to front 
        if (this.CompareTag("LandTrigger"))
        {
            if (other.CompareTag("Player"))
            {
                LandTriggerEvent.Invoke();
            }
        }
         //enemy hit   
        if (this.CompareTag("Enemy"))
        {
            if (other.CompareTag("Projectile"))
            {
                int score = this.transform.GetComponent<Enemy>().TakeDamage();
                if (score > 0)
                {
                    //print("Invoking Event");
                    //PointEvent.Invoke();
                    GameObject.Find("Player").GetComponent<Player>().AddScore();
                }
                
            }
        }
        //player hit
        if (this.CompareTag("Player"))
            if (other.CompareTag("Projectile"))
            {
                PlayerHitEvent.Invoke();
            }
        //enemy spotted player
        if (this.CompareTag("Detection"))
        {
            
            if (other.CompareTag("Player"))
            {

               GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
        if (other.CompareTag("Projectile") && this.transform.tag!= "Detection")
            Destroy(other.gameObject);
            
    }
    private void OnTriggerStay(Collider other)
    {
        //enemy knows about player
        if (this.CompareTag("Detection"))
        {
          
            if (other.CompareTag("Player"))
            {
    
                GetComponentInParent<Enemy>().SetTarget(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //allow movement 
        if (other.CompareTag("Player"))
        {
            if (this.name == "LeftBorder")
                other.transform.GetComponent<Player>().canMoveLeft = true;
            if (this.name == "RightBorder")
                other.transform.GetComponent<Player>().canMoveRight = true;
            if (this.name == "BackBorder")
                other.transform.GetComponent<Player>().canMoveBack = true;
        }
        //allow shooting
        if (this.CompareTag("Player") && other.CompareTag("Obsticle"))
        {
            this.gameObject.GetComponent<SoundManager>().PlaySound("ruffle");
            this.gameObject.GetComponent<Player>().canShoot = true;
        }
    }

}

