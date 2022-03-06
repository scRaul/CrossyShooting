using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    ParticleSystem spark;
    Light flash;
    SoundManager soundFx;
    int cap = 7;
    public int magSize;
    //float fireRate = 1f;
    private void Awake()
    {
        magSize = cap;
        spark = GetComponentInChildren<ParticleSystem>();
        flash = GetComponentInChildren<ParticleSystem>().GetComponentInChildren<Light>();
        soundFx = GetComponent<SoundManager>();
        flash.enabled = false;
    }
    public void Fire()
    {
        
        if (magSize > 0) {
            flash.enabled = true;
            spark.Play();
            soundFx.PlaySound("shot");
            flash.enabled = false;
            Instantiate(bullet, transform.position,transform.rotation);
            magSize--;
          }
        else
            soundFx.PlaySound("empty");


    }
    public void Reload()
    {
        soundFx.PlaySound("reload");
        magSize = 0;
        StartCoroutine(Fill());
    }
    IEnumerator Fill()
    {
        yield return new WaitForSeconds(.2f);
        magSize = cap;
    }
  
}
/*
Class Gun
    Data Members:

        GameObject bullet;
        ParticleSystem flash;
        int magSize;
        float fireRate;

    Functions:

        Update();//auto reload 
        Fire();
        Reload();
        

    
    
 */