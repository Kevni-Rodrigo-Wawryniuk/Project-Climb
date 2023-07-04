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
    [SerializeField] float speedMoviment, forceJump, forceDown;
    [SerializeField] int numberOfJump, maxJumps;

    [Header("Detect Floor")]
    [SerializeField] Vector2 sizeDetector;
    [SerializeField] Vector2 positionDetector;
    [SerializeField] LayerMask layerFloor;

    [Header("Interactuar")]
    [SerializeField] bool interact;
    [SerializeField] Transform positionCollider;
    [SerializeField] LayerMask layerInteract;
    [SerializeField] float timeInteract, radioInteract;

    [Header("Live")]
    [SerializeField] int live;

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
        interact = true;

        live = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        interactWithLever();
        StateOfLife();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y + positionDetector.y), sizeDetector);

        Gizmos.DrawWireSphere(positionCollider.position, radioInteract);

    }
    bool DetectFloor()
    {
        RaycastHit2D boxCast = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y + positionDetector.y),
                                                    sizeDetector, 0, Vector2.zero, 0, layerFloor);

        return boxCast.collider != null;
    }
    void Moviment()
    {
        if(move == true && live > 0)
        {
            if (DetectFloor())
            {
                numberOfJump = maxJumps;
            }

            // Derecha
            if (Input.GetKey(KeyCode.D))
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
                rgbPlayer.velocity = new Vector2(0, rgbPlayer.velocity.y);
                animPlayer.SetBool("Move", false);
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
    void StateOfLife()
    {
        if (live <= 0)
        {
            GameManagerPlay.gameManagerPlay.play = false;
            GameManagerPlay.gameManagerPlay.playerDead = true;
            GameManagerPlay.gameManagerPlay.playerWin = false;
        }

        if(transform.position.y >= 48)
        {
            GameManagerPlay.gameManagerPlay.play = false;
            GameManagerPlay.gameManagerPlay.playerDead = false;
            GameManagerPlay.gameManagerPlay.playerWin = true;
        }
    }
    void interactWithLever()
    {
        if(Input.GetKeyDown(KeyCode.E) && interact == true)
        {
            StartCoroutine(InteractiveLever());
        }
    }
    IEnumerator InteractiveLever()
    {
        move = false;
        interact = false;

        Collider2D[] objects = Physics2D.OverlapCircleAll(positionCollider.position, radioInteract);

        foreach (Collider2D collider2D in objects)
        {
            if(collider2D.gameObject.CompareTag("Lever"))
            {
                collider2D.gameObject.GetComponent<Lever>().OpenorClose();
            }
        }

        yield return new WaitForSeconds(timeInteract);

        move = true;
        interact = true;
    }
}
