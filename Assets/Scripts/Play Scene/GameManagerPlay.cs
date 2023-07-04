using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerPlay : MonoBehaviour
{
    [SerializeField] public static GameManagerPlay gameManagerPlay;

    [SerializeField] Transform positionPlayer;
    [SerializeField] BoxCollider2D[] boxCollider2DsLevers;

    [Header("State Of Game")]
    [SerializeField] public bool play;
    [SerializeField] public bool playerDead;
    [SerializeField] public bool playerWin;
    [SerializeField] bool pause;

    [Header("Control Canvas")]
    [SerializeField] Canvas[] Screens;
    [SerializeField] TextMeshProUGUI textTimeGame;
    [SerializeField] TextMeshProUGUI textHeigthPlayer;
    [SerializeField] int minut, second;
    [SerializeField] float microSecond;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(gameManagerPlay == null)
        {
            gameManagerPlay = this;
        }

        play = true;
        playerDead = false;
        playerWin = false;
        pause = false;

        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        controlCanvas();
        DisappearLevers();
    }
    
    void controlCanvas()
    {
        Screens[0].enabled = play;
        Screens[1].enabled = playerDead;
        Screens[2].enabled = playerWin;
        Screens[3].enabled = pause;

        textHeigthPlayer.text = "Height: " + positionPlayer.position.y;
        textTimeGame.text = "Time The Game: " + minut + ":" + second;

        if(microSecond == 60)
        {
            second++;
            microSecond = 0;
        }
        if(second == 60)
        {
            minut++;
            second = 0;
        }

        // Jugando
        if(playerDead == false && playerWin == false)
        {
            microSecond += 1 * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pause = !pause;
            }
        }

        if(pause == true)
        {
            microSecond = 0;
            Time.timeScale = 0;
            play = false;
        }
        else
        {
            Time.timeScale = 1;
            play = true;
        }

        // Perdiste
        if(playerDead == true && playerWin == false)
        {
            microSecond = 0;
            Time.timeScale = 0;
        }
        // ganaste
        if (playerDead == false && playerWin == true)
        {
            microSecond = 0;
            Time.timeScale = 0;
        }
    }
    void DisappearLevers()
    {
        if(positionPlayer.position.x < -7 && positionPlayer.position.x > -9 && positionPlayer.position.y > 37)
        {
            if(Input.GetKeyDown(KeyCode.E) && boxCollider2DsLevers[0].enabled == true)
            {
                Lever.lever.levers++;
                Lever.lever.spriteRenderers[2].enabled = false;
                Lever.lever.spriteRenderers[3].enabled = true;
                boxCollider2DsLevers[0].enabled = false;
            }
        }
        if(positionPlayer.position.x < 81 && positionPlayer.position.x > 79 && positionPlayer.position.y > 44)
        {
            if (Input.GetKeyDown(KeyCode.E) && boxCollider2DsLevers[1].enabled == true)
            {
                Lever.lever.levers++;
                Lever.lever.spriteRenderers[4].enabled = false;
                Lever.lever.spriteRenderers[5].enabled = true;
                boxCollider2DsLevers[1].enabled = false;
            }
        }
    }
    public void ReturnGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void ReturnMenuPrincipal()
    {
        PlayerPrefs.SetInt("Scene", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }


}
