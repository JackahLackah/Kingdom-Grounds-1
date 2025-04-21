using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //THIS CODE IS UPDATED
    
    private Rigidbody2D body;
    [Header("Horizontal Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;

    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        if(wallJumpCooldown < 0.2f)
        Jump();
    }
    
    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && body.linearVelocity.y > 0)
        {
            //body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
        }

        if (Input.GetKey(KeyCode.W) && Grounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
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
}
