using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] public static MainPlayer mainPlayer;

    private Rigidbody2D rgbPlayer;
    private Animator animPlayer;

    [Header("Moviment")]
    [SerializeField] public bool move;
    [SerializeField] float speedMoviment, forceJump;
    [SerializeField] int numberOfJump, maxJumps;

    [Header("Detect Floor")]
    [SerializeField] Vector2 sizeDetector;
    [SerializeField] Vector2 positionDetector;
    [SerializeField] LayerMask layerFloor;

    // Start is called before the first frame update
    void Start()
    {
        StarProgram();
    }

    void StarProgram()
    {
        if(mainPlayer == null)
        {
            mainPlayer = this;
        }
        rgbPlayer = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y + positionDetector.y), sizeDetector);
    }
    bool DetectFloor()
    {
        RaycastHit2D boxCast = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y + positionDetector.y),
                                                    sizeDetector, 0, Vector2.zero, 0, layerFloor);

        return boxCast.collider != null;
    }
    void Moviment()
    {
        if(move == true)
        {
            // Derecha
            if(Input.GetKey(KeyCode.D))
            {
                rgbPlayer.velocity = new Vector2(speedMoviment, rgbPlayer.velocity.y);
                animPlayer.SetBool("Move", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            // Izquierda
            else if(Input.GetKey(KeyCode.A))
            {
                rgbPlayer.velocity = new Vector2(-speedMoviment, rgbPlayer.velocity.y);
                animPlayer.SetBool("Move", true);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                rgbPlayer.velocity = new Vector2(rgbPlayer.velocity.x, rgbPlayer.velocity.y);
                animPlayer.SetBool("Move", false);
            }
            
            if (DetectFloor())
            {
                numberOfJump = maxJumps;
            }

            if (numberOfJump > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                rgbPlayer.AddForce(new Vector2(rgbPlayer.velocity.x, forceJump));
                numberOfJump--;
                animPlayer.SetBool("Jump", true);
            }

            if(numberOfJump == maxJumps)
            {
                animPlayer.SetBool("Jump", false);
            }
        }
    }
}
