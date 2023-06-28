using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class GameManagerStat : MonoBehaviour
{
    [SerializeField] public static GameManagerStat gameManagerStat;

    [Header("Active Bottons")]
    [SerializeField] bool bottonStart;
    [SerializeField] bool bottonSettings;
    [SerializeField] bool movePlayer;

    [Header("Time Pase Scene")]
    [SerializeField] float timeScene;
    [SerializeField] float endTimeScene;

    [Header("Object In Scene")]
    [SerializeField] GameObject[] objectsInScene;
    [SerializeField] List<GameObject> groundLandList;
    [SerializeField] List<GameObject> cloudsList;
    [SerializeField] List<GameObject> treesList;
    [SerializeField] float speedGroundX, speedCloudsX, speedTreesX, speedSkyX;
    [SerializeField] Canvas[] canvasInScene;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(gameManagerStat == null)
        {
            gameManagerStat = this;
        }

        bottonStart = true;
        bottonSettings = false;
        movePlayer = false;

        // Velocidades de los objetos en scena
        speedGroundX = 1;
        speedCloudsX = 2;
        speedTreesX = 1;
        speedSkyX = 0.1f;

        endTimeScene = 1.5f;

        // Coloco Al jugador en la scena
        Instantiate(objectsInScene[0], new Vector3(-8, -3.2f, 0), Quaternion.identity);

        // Esto hace que se coloque el suelo si el ujgador no a iniciado el juego
        if(bottonStart == true)
        {
            for ( int i = 0; i < 2; i++)
            {
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-7, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-6, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-5, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-4, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-3, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-2, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(-1, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(0, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(1, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(2, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(3, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(4, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(5, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(6, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(7, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(8, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(9, -4), Quaternion.identity));
                groundLandList.Add(Instantiate(objectsInScene[1], new Vector2(10, -4), Quaternion.identity));
            }
            for (int i = 0; i < 1; i++)
            {
                // arbol 8 / 9
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(-7, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(-6, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(-5, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(-4, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(-3, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(-2, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(-1, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(0, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(1, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(2, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(3, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(4, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(5, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(6, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(7, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(8, -2.55f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[8], new Vector2(9, -2.65f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[9], new Vector2(10, -2.55f), Quaternion.identity));

                // arbol 10
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-7.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-6.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-5.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-4.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-3.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-2.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-1.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(-0.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(0.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(1.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(2.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(3.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(4.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(5.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(6.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(7.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(8.5f, -2.6f), Quaternion.identity));
                treesList.Add(Instantiate(objectsInScene[10], new Vector2(9.5f, -2.6f), Quaternion.identity));
            }
        }
        
        for (int i = 0; i < 4; i++)
        {
            cloudsList.Add(Instantiate(objectsInScene[2], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
            cloudsList.Add(Instantiate(objectsInScene[3], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
            cloudsList.Add(Instantiate(objectsInScene[4], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
            cloudsList.Add(Instantiate(objectsInScene[5], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
            cloudsList.Add(Instantiate(objectsInScene[6], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
            cloudsList.Add(Instantiate(objectsInScene[7], new Vector2(Random.Range(30, 100), Random.Range(-0.8f, 4)), Quaternion.identity));
        }

    }

    // Update is called once per frame
    void Update()
    {
        ControlCanvas();

        PlaceThePlayer();

        PlacetheObjectInBackGround();
    }

    // Esto posiciona al jugador en la scena y lo mueve por toda la scena 
    void PlaceThePlayer()
    {
        if (bottonStart == true || bottonSettings == true)
        {
            // buscar al jugador
            objectsInScene[0] = GameObject.FindGameObjectWithTag("Player");

            if (objectsInScene[0].transform.position.x < -4 && movePlayer == false)
            {
                objectsInScene[0].transform.position += new Vector3(transform.position.x + 2 * Time.deltaTime, 0, 0);
            }
        }

        // Esto era cuando se ingresa a jugar el juego
        if (bottonStart == false && bottonSettings == false)
        {
            if(objectsInScene[0].transform.position.x < 7.5)
            {
                objectsInScene[0].transform.position += new Vector3(transform.position.x + 2 * Time.deltaTime, 0, 0);
            }
            if (objectsInScene[0].transform.position.x >= 7.5 && objectsInScene[0].transform.position.x < 11.8)
            {
                objectsInScene[0].transform.position += new Vector3(transform.position.x + 16 * Time.deltaTime, 0, 0);
            }
            if(objectsInScene[0].transform.position.x >= 11.8 && objectsInScene[0].transform.position.x < 20)
            {
                objectsInScene[0].transform.position += new Vector3(transform.position.x + 2 * Time.deltaTime, 0, 0);
            }

            if (objectsInScene[0].transform.position.x > 11.8)
            {
                objectsInScene[11].transform.position = new Vector3(20, 0, -10);
            }

            if(objectsInScene[0].transform.position.x >= 20)
            {
                objectsInScene[0].GetComponent<Animator>().SetTrigger("Get-In");
                timeScene += 1 * Time.deltaTime;

                if(timeScene >= endTimeScene)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
    // Esto mueve el suelo
    void PlacetheObjectInBackGround()
    {
        // Esto mueve el suelo
        if (bottonStart == true || bottonSettings == true)
        {
            for (int i = 0; i < groundLandList.Count; i++)
            {
                if (groundLandList[i].transform.position.x < -8)
                {
                    groundLandList[i].transform.position = new Vector3(10, -4, 0);
                }
                groundLandList[i].transform.position = groundLandList[i].transform.position + new Vector3(-speedGroundX, 0, 0) * Time.deltaTime;
            }

            for (int i = 0; i < treesList.Count; i++)
            {
                if(treesList[i].transform.position.x < -9)
                {
                    treesList[i].transform.position = new Vector3(9,Random.Range(-2.6f,-2.65f),0);
                }

                treesList[i].transform.position = treesList[i].transform.position + new Vector3(-speedTreesX, 0, 0) * Time.deltaTime;
            }
        }

        // Esto mueve las nuves
        for (int i = 0; i < cloudsList.Count; i++)
        {
            if(cloudsList[i].transform.position.x < -10)
            {
                cloudsList[i].transform.position = new Vector3(Random.Range(30, 60), Random.Range(-0.8f, 4), 0);
            }
            cloudsList[i].transform.position = cloudsList[i].transform.position + new Vector3(-speedCloudsX, 0, 0) * Time.deltaTime;
        }

        // Aca se mueve el cielo
        objectsInScene[12].GetComponent<MeshRenderer>().material.mainTextureOffset = objectsInScene[12].GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(speedSkyX * Time.deltaTime, 0);
    }
    // control de las pantallas 
    void ControlCanvas()
    {
        canvasInScene[0].enabled = bottonStart;
        canvasInScene[1].enabled = bottonSettings;
    }

    // Estos son los botones a presionar  
    public void UseBottonStart()
    {
        if(bottonStart == true && bottonSettings == false)
        {
            bottonStart = !bottonStart;

            PlayerPrefs.SetInt("Scene", 2);
        }
    }
    public void UseBottonSetting()
    {
         bottonSettings = !bottonSettings;
         bottonStart = !bottonStart;
    }
    public void UseBottonQuit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
