using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public static Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        StartProgram();
    }

    void StartProgram()
    {
        if(bullet == null)
        {
            bullet = this;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MainPlayer.mainPlayer.live--;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }  
        if(collision.gameObject.CompareTag("Point"))
        {
            Destroy(this.gameObject);
        }
    }
}
