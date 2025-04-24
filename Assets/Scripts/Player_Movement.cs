using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float jumpTime;
    private int availableJumps;
    private bool isJumping;

    [Header("Horizontal Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float jumpHoldFrames;
    [SerializeField] private int maxJumps;


    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        print("on");
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        //if (wallJumpCooldown < 0.2f)

        Jump();
        Grounded();
    }

    void Jump()
    {
        //reset jump count
        if (Grounded())
        {
            availableJumps = 0;
        }
        else if(availableJumps == 0)
        {
            availableJumps = 1;
            print("1");
        }
        //initiate jump
        if (Input.GetKey(KeyCode.W) && availableJumps < maxJumps)
        {
            availableJumps++;
            jumpTime = jumpHoldFrames;
            print("2");
        }

        //end jump early
        //if (!get)
        {
            //jumpTime = 0;
            //print("3");
        }

        //jump based on the timer
        if (jumpTime > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
            jumpTime--;
            print("4");
        }
    }

    public bool Grounded()
    {
        if (Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, whatIsWall);
        return raycastHit.collider != null;
    }
}


    //OLD TBD CODE

    /*
    if (Input.GetKey(KeyCode.W) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        }



    if (availableJumps > 0)
        {
            if (Input.GetKey(KeyCode.W) && Grounded())
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jump);

    jumpTime = jumpStartTime;
                isJumping = true;
                availableJumps++;
            }

if (Input.GetKey(KeyCode.W) && isJumping == true)
{
    if (jumpTime > 0)
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        jumpTime -= Time.deltaTime;
    }
    else
    {
        isJumping = false;
    }
}

if (Input.GetKeyUp(KeyCode.W))
{
    isJumping = false;
}
        }
}
    */
