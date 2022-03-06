using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;
    Health health;
    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
        health = transform.GetComponentInParent<Health>();
       

    }
    private void Update()
    {
        if(health != null)
            slider.value = health.life;
    }
    /*
     class HealthBar
        Data members:

                Slider slider;
                Health health;
         Functions:

                Awake()// get parent health component
                Update()//update bar to equal life left

            
     */

}
