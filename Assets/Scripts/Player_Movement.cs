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
    [SerializeField] private float jumpStartTime;
    [SerializeField] private int maxJumps;


    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;

    Animator animator;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    private void Update() {
        float horizontalvelocity = Input.GetAxis("Horizontal") * speed;
        body.linearVelocity = new Vector2(horizontalvelocity, body.linearVelocity.y);

        //if(wallJumpCooldown < 0.2f)
        Jump();

        animator.SetFloat("Speed", horizontalvelocity);
    }
    
    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && Grounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);

            jumpTime = jumpStartTime;
            isJumping = true;
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

        if(Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        //HIGHER GRAVITY WHEN FALLING
        if(body.linearVelocity.y < 0)
        {
            
        }
    }

    public bool Grounded()
    {
        if(Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
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


    //OLD TBD CODE

    /*
    if (Input.GetKey(KeyCode.W) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        }
        */
}
