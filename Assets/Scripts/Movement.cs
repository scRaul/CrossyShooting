using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    SoundManager soundFx; 
    public float speed = 1f;
    bool jumping = false;
    float waitTime = .1f;

 
    Quaternion initial;
    float grounded;
    private void Awake()
    {
        soundFx = GetComponent<SoundManager>();
        initial = transform.rotation;
        grounded = transform.position.y;
    }
    public void MoveRight()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y +90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveLeft()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveFoward()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }
    public void MoveBack()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,-speed * Time.deltaTime, Space.World);
    }
    private void Jump()
    {
        
        if (!jumping)
        {
            soundFx.PlaySound("jump");
            jumping = true;
            transform.position = new Vector3(transform.position.x, grounded + 1, transform.position.z);
            StartCoroutine(Floor());
        }
    }
    IEnumerator Floor()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = new Vector3(transform.position.x, grounded, transform.position.z);
        StartCoroutine(SetJump());
    }
    IEnumerator SetJump()
    {
        yield return new WaitForSeconds(waitTime);
        jumping = false;
    }


}
/*
 Class Movement
    Data members:

        float speed;

        float grounded;
        bool jumping;       //used to jump
        float waitTime;

        Quaternion intital;//intital rotation

     Functions:
        MoveLeft()
        MoveRight()
        MoveFoward()
        MoveBack()
        Jump();
        
        
            
*/