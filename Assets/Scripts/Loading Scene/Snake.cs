using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Snake : MonoBehaviour
{
    [SerializeField] public static Snake snake;

    enum Direccion
    {
        up,
        down,
        right,
        left,
    }

    Direccion direccion;

    public float timeFps, distancefps;

    Vector3 lastpos;

    public List<GameObject> tailLst = new List<GameObject>();


    public GameObject tailPrefab;

    [SerializeField] public bool Muerta;
    [SerializeField] public bool lastPoint;

    [SerializeField] TextMeshProUGUI textPoints;
    [SerializeField] TextMeshProUGUI textLastPoints;

    [SerializeField] public int point;

    [SerializeField] Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        Muerta = false;
        StartProgram();
    }

    void StartProgram()
    {
        if(snake == null)
        {
            snake = this;
        }

        startPosition = transform.position;

        InvokeRepeating("Move", timeFps, timeFps);
    }
    // Update is called once per frame
    void Update()
    {
        Moviment();
        SeePoints();
        ReturnGame();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Edges"))
        {
            print("Perdiste");
            GameManagerLoading.gameManagerLoading.Play = false;
            Muerta = true;
            lastPoint = true;
        }

        if(collision.gameObject.CompareTag("Food"))
        {
           tailLst.Add(Instantiate(tailPrefab, tailLst[tailLst.Count - 1].transform.position, Quaternion.identity));

            collision.transform.position = new Vector2(Random.Range(-7.5f, 7.5f), Random.Range(-3.3f, 4.3f));

            point++;
        }

        if(collision.gameObject.CompareTag("Tails"))
        {
            Muerta = true;
            lastPoint = true;
            GameManagerLoading.gameManagerLoading.Play = false;
            print("Cola");
        }
    }

    void Move()
    {
        if (Muerta == false && GameManagerLoading.gameManagerLoading.Play == true)
        {
            lastpos = transform.position;
            // Esto es para darle la posicion a la serpiente
            Vector3 nextPos = Vector3.zero;
            // Las siguientes afirmaciones son los movimientos
            // arriba
            if (direccion == Direccion.up)
            {
                nextPos = Vector3.up;
            }
            // abajo
            else if (direccion == Direccion.down)
            {
                nextPos = Vector3.down;
            }
            // Derecha
            else if (direccion == Direccion.right)
            {
                nextPos = Vector3.right;
            }
            // Izquierda
            else if (direccion == Direccion.left)
            {
                nextPos = Vector3.left;
            }
            // Transformar la posicion de la serpiente
            nextPos *= distancefps;

            transform.position += nextPos;

            MoveTail();
        }
    }
    void Moviment()
    {
        if (Muerta == false && GameManagerLoading.gameManagerLoading.Play == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                direccion = Direccion.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                direccion = Direccion.down;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                direccion = Direccion.right;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                direccion = Direccion.left;
            }
        }
    }
    void MoveTail()
    {
        if (Muerta == false && GameManagerLoading.gameManagerLoading.Play == true)
        {
            for (int i = 0; i < tailLst.Count; i++)
            {
                Vector3 temp;
                temp = tailLst[i].transform.position;
                tailLst[i].transform.position = lastpos;
                lastpos = temp;
            }
        }
    }

    void SeePoints()
    {
        textPoints.text = "Points: " + point;
        textLastPoints.text = "LastPoints: " + point;
    }
    void ReturnGame()
    {
        if (Muerta == true && lastPoint == true && GameManagerLoading.gameManagerLoading.Play == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.position = startPosition;
                Muerta = false;
                lastPoint = false;
                GameManagerLoading.gameManagerLoading.Play = false;

                point = 0;

                for (int i = 0; i < tailLst.Count; i++)
                {
                    Destroy(tailLst[i]);
                    tailLst.RemoveAt(i);
                }
            }
        }
    }
}
