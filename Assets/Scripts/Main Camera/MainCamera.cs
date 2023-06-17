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
       // PositionTheCamera();
    }
    void PositionTheCamera()
    {
        // Asi hacemos que dependiendo de la posicion del jugador la camara se mueva de su posicion
        if(positionPlayer.position.y < 10)
        {
            transform.position = new Vector3(0, 0, -10);
        }
        else if(positionPlayer.position.y >= 10)
        {
            transform.position = new Vector3(0, 20, -10);
        }

    }

}

