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
        if(positionPlayer.position.x < 9f && positionPlayer.position.y < 5)
        {
            transform.position = new Vector3(0, 0, -10);
        }
        // 2 posicion
        if(positionPlayer.position.x > 9f && positionPlayer.position.y < 5)
        {
            transform.position = new Vector3(18, 0, -10);
        }
        // 3 posicion
        if(positionPlayer.position.x > 27f && positionPlayer.position.y < 5)
        {
            transform.position = new Vector3(36, 0, -10);
        }


        if(positionPlayer.position.y > 5)
        {
            transform.position = new Vector3(36, 10, -10);
        }
        if(positionPlayer.position.y > 15)
        {
            transform.position = new Vector3(36, 20, -10);
        }
        if(positionPlayer.position.y > 25)
        {
            transform.position = new Vector3(36, 30, -10);
        }
        if(positionPlayer.position.y > 35)
        {
            transform.position = new Vector3(36, 40, -10);
        }
        if (positionPlayer.position.y > 46)
        {
            transform.position = new Vector3(36, 50, -10);
        }
        

        // Primera puerta 
        if (positionPlayer.position.y > 35 && positionPlayer.position.y < 46)
        {
            if (positionPlayer.position.x > 45)
            {
                transform.position = new Vector3(54, 41.5f, -10);
            }
            if (positionPlayer.position.x > 63)
            {
                transform.position = new Vector3(72, 41.5f, -10);
            }
            if (positionPlayer.position.x < 27)
            {
                transform.position = new Vector3(18, 41.5f, -10);
            }
            if (positionPlayer.position.x < 9)
            {
                transform.position = new Vector3(0, 41.5f, -10);
            }
        }
    }
}

