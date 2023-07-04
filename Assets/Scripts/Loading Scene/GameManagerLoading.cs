using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerLoading : MonoBehaviour
{
    [SerializeField] public static GameManagerLoading gameManagerLoading;

    [SerializeField] Slider sliderLoading;
    [SerializeField] public int scene;
    [SerializeField] GameObject[] panels;

    [SerializeField] public bool Play;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(gameManagerLoading == null)
        {
            gameManagerLoading = this;
        }

       scene = PlayerPrefs.GetInt("Scene", 0);
        
       StartCoroutine(LoadScenes(scene));

       Play = false;
    }

    // Update is called once per frame
    void Update()
    {
        controlScreens();
    }
    void controlScreens()
    {
        // panel con el tutorial
        if (Play == false && Snake.snake.Muerta == false && Snake.snake.lastPoint == false)
        {
            panels[0].SetActive(true);
        }
        else
        {
            panels[0].SetActive(false);
        }
        if(Play == true && Snake.snake.Muerta == false)
        {
            panels[1].SetActive(true);
        }
        else
        {
            panels[1].SetActive(false);
        }
        panels[2].SetActive(Snake.snake.lastPoint);

        if(Play == false)
        {
            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Play = true;
            }
            if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Play = true;
            }
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Play = true;
            }
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Play = true;
            }
        }
    }

    IEnumerator LoadScenes(int SceneValue)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneValue);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            sliderLoading.value = operation.progress;

            if(operation.progress >= 0.9f)
            {
                if(Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}
