using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] public static MainPlayer mainPlayer;

    private Rigidbody2D rgbPlayer;

    [Header("Moviment")]
    [SerializeField] public bool move;
    [SerializeField] float speedMoviment, forceJump;
    [SerializeField] int numberOfJump;
    private int maxJumps = 1;

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
            float movimentX = Input.GetAxis("Horizontal");

            rgbPlayer.velocity = new Vector2(movimentX * speedMoviment, rgbPlayer.velocity.y);

            if(numberOfJump > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                rgbPlayer.AddForce(new Vector2(rgbPlayer.velocity.x, forceJump));
                numberOfJump--;
            }
            if(DetectFloor())
            {
                numberOfJump = maxJumps;
            }
        }
    }
}
