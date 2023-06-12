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
        
    }
}
