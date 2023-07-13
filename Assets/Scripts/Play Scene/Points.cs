using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] public static Points points;

    [SerializeField] float rotate;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(points == null)
        {
            points = this;
        }
    }
    void Update()
    {
        rotate = Random.Range(0, 90);
        transform.Rotate(new Vector3(rotate* Time.deltaTime, rotate * Time.deltaTime, rotate * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MainPlayer.mainPlayer.points++;
            Destroy(this.gameObject);
        }
    }
}
