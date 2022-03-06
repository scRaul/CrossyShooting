using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadChicken : MonoBehaviour
{
    Gun gun;
    Movement move;
    bool complete = false;
    bool canMove = false;
    private void Awake()
    {
        gun = GetComponentInChildren<Gun>();
        move = GetComponent<Movement>();
        StartCoroutine(Move());
    }
    private void Update()
    {
        if (canMove)
        {
            if (transform.position.x < -1.0)
                move.MoveRight();
            else
            {
                if (!complete)
                {
                    complete = true;
                    move.MoveBack();
                    StartCoroutine(Shoot());
                }

            }
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(.2f);
        gun.Fire();
        StartCoroutine(LoadGame());
        
    }
    IEnumerator Move()
    {

        yield return new WaitForSeconds(.5f);
        canMove = true;

    }
    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene("GameLoop");
    }

}
