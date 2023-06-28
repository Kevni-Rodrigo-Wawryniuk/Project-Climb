using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPlay : MonoBehaviour
{
    [SerializeField] public static GameManagerPlay gameManagerPlay;

    [Header("State Of Game")]
    [SerializeField] bool play;
    [SerializeField] bool playerDead;
    [SerializeField] bool playerWin;
    [SerializeField] bool pause;

    [Header("Objects In Scene")]
    [SerializeField] GameObject[] objetcsInScene;

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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
