using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public static Platform platform;

    [Header("Moviments")]
    [SerializeField] bool moviment;
    [SerializeField] int move;

    [Header("move Right or left")]
    [SerializeField] float speed0;
    [SerializeField] GameObject[] pointsMoviment;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(platform == null)
        {
            platform = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Moviment();
    }

    void Moviment()
    {
        if(moviment == true)
        {
            switch(move)
            {
                // mover de izquierda a derecha o viceversa
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, pointsMoviment[0].transform.position, speed0 * Time.deltaTime);

                    if (transform.position.x == pointsMoviment[1].transform.position.x) 
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[2].transform.position;
                    }
                    if (transform.position.x == pointsMoviment[2].transform.position.x)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[1].transform.position;
                    }
                        break;
                // mover de arriba a abajo o biceverza
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, pointsMoviment[0].transform.position, speed0 * Time.deltaTime);

                    if(transform.position.y == pointsMoviment[1].transform.position.y)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[2].transform.position;
                    }
                    if(transform.position.y == pointsMoviment[2].transform.position.y)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[1].transform.position;
                    }
                    break;
                // mover en circulos
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, pointsMoviment[0].transform.position, speed0 * Time.deltaTime);

                    if(transform.position == pointsMoviment[1].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[2].transform.position;
                    }
                    if(transform.position == pointsMoviment[2].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[3].transform.position;
                    }
                    if (transform.position == pointsMoviment[3].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[4].transform.position;
                    }
                    if (transform.position == pointsMoviment[4].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[5].transform.position;
                    }
                    if (transform.position == pointsMoviment[5].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[6].transform.position;
                    }
                    if (transform.position == pointsMoviment[6].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[7].transform.position;
                    }
                    if(transform.position == pointsMoviment[7].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[8].transform.position;
                    }
                    if(transform.position == pointsMoviment[8].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[1].transform.position;
                    }

                    break;
                // mover haciendo un cubo
                case 4:

                    transform.position = Vector3.MoveTowards(transform.position, pointsMoviment[0].transform.position, speed0 * Time.deltaTime);

                    if (transform.position == pointsMoviment[1].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[2].transform.position;
                    }
                    if (transform.position == pointsMoviment[2].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[3].transform.position;
                    }
                    if (transform.position == pointsMoviment[3].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[4].transform.position;
                    }
                    if (transform.position == pointsMoviment[4].transform.position)
                    {
                        pointsMoviment[0].transform.position = pointsMoviment[1].transform.position;
                    }

                    break;
                default:

                    break;
            }
        }
    }
}
