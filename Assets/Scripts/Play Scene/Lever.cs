using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] public static Lever lever;

    [SerializeField] Transform positionPlayer;

    [Header("Open Doors")]
    [SerializeField] public SpriteRenderer[] spriteRenderers;
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] pointOpenOrClose;
    [SerializeField] float speedX, speedY, speedZ;
    [SerializeField] float timeOpenDoor, endTimeOpenDoor;
    [SerializeField] bool openFirstDoor, openSecondDoor;
    [SerializeField] public int levers;

    [SerializeField] bool firstLever, secondLever;
    [SerializeField] float timetutorial, endTutorial;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(lever == null)
        {
            lever = this;
        }

        positionPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }
    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
       // Primera puerta para acceder a la zoma de juego
        if (openFirstDoor == false)
        {
            spriteRenderers[0].enabled = true;
            spriteRenderers[1].enabled = false;
                    doors[0].transform.position = Vector3.MoveTowards(doors[0].transform.position, pointOpenOrClose[0].transform.position, speedY);
        }
        if (openFirstDoor == true)
        {
            spriteRenderers[0].enabled = false;
            spriteRenderers[1].enabled = true;
            doors[0].transform.position = Vector3.MoveTowards(doors[0].transform.position, pointOpenOrClose[1].transform.position, speedY);
        }
        if(positionPlayer.position.x > 27)
        {
          openFirstDoor = false;
        }

        if( openSecondDoor == false)
        {
            doors[1].transform.Rotate(new Vector3(0, 0, 0));
        }
        if(openSecondDoor == true)
        {
            timeOpenDoor += 1 * Time.deltaTime;
            doors[1].transform.Rotate(new Vector3(0, 0, speedZ) * Time.deltaTime);
        }

        if(timeOpenDoor < endTimeOpenDoor && levers == 2)
        {
            openSecondDoor = true;
        }

        if(timeOpenDoor >= endTimeOpenDoor)
        {
            speedZ = 0;
            openSecondDoor = false;
        }

    }

    public void OpenorClose()
    {
        if (positionPlayer.position.y < 10)
        {
            openFirstDoor = !openFirstDoor;
        }
    }
}
