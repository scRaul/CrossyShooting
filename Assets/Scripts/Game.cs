using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    Canvas gui;
    World world;
    Player player;
    Text rounds, score, gameOver,controls;
    void Awake()
    {
        player = GetComponentInChildren<Player>();
        world = GetComponentInChildren<World>();
        gui = GetComponentInChildren<Canvas>();
        rounds = gui.transform.Find("Rounds").GetComponent<Text>();
        score = gui.transform.Find("Score").GetComponent<Text>();
        gameOver = gui.transform.Find("GameOver").GetComponent<Text>();
        controls = gui.transform.Find("Controls").GetComponent<Text>();
    }
   
    private void FixedUpdate()
    {
        rounds.text = player.GetComponentInChildren<Gun>().magSize.ToString() + " / - ";
        score.text = player.score.ToString();
    }
    public void  Restart()
    {
        gameOver.enabled = true;
        StartCoroutine(LoadIntro());
    }
    IEnumerator LoadIntro()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Intro");

    }
    private void Update()
    {
        if (Input.anyKey)
        {
            if (controls.enabled)
                StartCoroutine(TakeOffCntrlText());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(QuitApp());
    }
    IEnumerator QuitApp()
    {
        gameOver.text = "GOODBYE";
        gameOver.enabled = true;
        yield return new WaitForSeconds(2f);
        gameOver.enabled = false;
        Application.Quit();
    }
    IEnumerator TakeOffCntrlText()
    {
        yield return new WaitForSeconds(.5f);
        controls.enabled = false;
    }
}
