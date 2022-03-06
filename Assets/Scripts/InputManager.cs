using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;

    private void Start()
    {
      player = GetComponent<Player>();
  
    }
    private void Update()
    {
        //transform.position = parent.position;
        if (Input.GetKey(KeyCode.D))
        {
            player.MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            player.MoveFoward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.MoveBack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
  
            player.Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            player.Reload();
        }
    }
}
/*
class InputManager
    Data Members:

        Gun gun;
        Movement movement;
    
    Functions:
        Update(); //listen for key presses and responed accordinally
*/

      