using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class Canyon : MonoBehaviour
{
    [SerializeField] public static Canyon canyon;

    [Header("Bullets")]
    [SerializeField] GameObject bullet, pointShooting;
    [SerializeField] bool shootingX, shootingY;
    [SerializeField] float forceShootingX, forceShootingY;

    [Header("timer Shooting")]
    [SerializeField] float timeShoot,secondTimerShoot, threeTimerShoot;
    [SerializeField] float endTimerShooting, endSecondTimerShooting,endThreeTimerShooting;
    [SerializeField] float timeControl;

    [Header("Comport")]
    [SerializeField] int comport;

    [SerializeField] AudioSource disparo;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(canyon == null)
        {
            canyon = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    void Shooting()
    {
        if(shootingX == true)
        {
            switch(comport)
            {
                // un disparo cada 2 segundos
                case 1:
                    // hara lo mismo pero en direccion contraria
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2
                    endTimerShooting = 3;

                    timeShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }
                    break;
                    // dos disparos cada 2 segundos
                case 2:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if(secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    break;
                    // tres disparos a la ves
                case 3:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;
                    endThreeTimerShooting = 3.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    threeTimerShoot += timeControl * Time.deltaTime;

                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    if(threeTimerShoot >= endThreeTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        threeTimerShoot = 0;
                        disparo.Play();
                    }
                    break;
                case 4:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    break;
                case 5:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;
                    endThreeTimerShooting = 3.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    threeTimerShoot += timeControl * Time.deltaTime;

                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    if (threeTimerShoot >= endThreeTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(-forceShootingX, 0);
                        threeTimerShoot = 0;
                        disparo.Play();
                    }
                    break;

                    // un disparo cada 2 segundos
                default:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2
                    endTimerShooting = 3;

                    timeShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(forceShootingX, 0);
                        timeShoot = 0;
                        disparo.Play();
                    }
                    break;
            }
        }

        if(shootingY == true)
        {
            switch(comport)
            {
                // un disparo cada 2 segundos
                case 1:
                    // hara lo mismo que en cero pero en direccion contraria
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2
                    endTimerShooting = 3;

                    timeShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }
                    break;
                case 2:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }
                    break;
                case 3:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;
                    endThreeTimerShooting = 3.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    threeTimerShoot += timeControl * Time.deltaTime;

                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    if (threeTimerShoot >= endThreeTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        threeTimerShoot = 0;
                        disparo.Play();
                    }
                    break;
                case 4:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }
                    break;
                case 5:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2

                    endTimerShooting = 3;
                    endSecondTimerShooting = 2.5f;
                    endThreeTimerShooting = 3.5f;

                    timeShoot += timeControl * Time.deltaTime;
                    secondTimerShoot += timeControl * Time.deltaTime;
                    threeTimerShoot += timeControl * Time.deltaTime;

                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }

                    if (secondTimerShoot >= endSecondTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        secondTimerShoot = 0;
                        disparo.Play();
                    }

                    if (threeTimerShoot >= endThreeTimerShooting)
                    {
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -forceShootingY);
                        threeTimerShoot = 0;
                        disparo.Play();
                    }
                    break;
                    // un disparo cada 2 segundos
                default:
                    // la fuerza de disparo sera de 15 y el tiempo de disparo sera de 2
                    endTimerShooting = 3;

                    timeShoot += timeControl * Time.deltaTime;
                    if (timeShoot >= endTimerShooting)
                    {
                        // esto solo funciona si el objeto a mover su rigidbody esta en estado dinamico
                        GameObject bullet0 = Instantiate(bullet, pointShooting.transform.position, Quaternion.identity);
                        bullet0.GetComponent<Rigidbody2D>().velocity = new Vector2(0, forceShootingY);
                        timeShoot = 0;
                        disparo.Play();
                    }
                    break;
            }

        }
    }
}
