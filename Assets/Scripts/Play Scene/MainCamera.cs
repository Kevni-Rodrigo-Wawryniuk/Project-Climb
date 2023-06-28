using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] public static MainCamera mainCamera;

    [Header("Detect Position Player")]
    [SerializeField] bool Player;
    [SerializeField] Transform positionPlayer;


    // Start is called before the first frame update
    void Start()
    {
        StarProgram();
    }

    void StarProgram()
    {
        if(mainCamera == null)
        {
            mainCamera = this;
        }
        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
      PositionTheCamera();
    }
    void PositionTheCamera()
    {
        // Asi hacemos que dependiendo de la posicion del jugador la camara se mueva de su posicion
        // Estas son las primeras posiciones en las que el jugador se puede mover 
        // posicion inicial
        if(positionPlayer.position.x < 7.5f && positionPlayer.position.y < 4)
        {
            transform.position = new Vector3(0, 0, -10);
        }
        // 2 posicion
        if(positionPlayer.position.x >= 7.5f && positionPlayer.position.y < 4)
        {
            transform.position = new Vector3(15, 0, -10);
        }
        // 3 posicion
        if(positionPlayer.position.x >= 22.5f && positionPlayer.position.y < 4)
        {
            transform.position = new Vector3(30, 0, -10);
        }
    }

}

