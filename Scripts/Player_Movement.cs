using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        Jump();
    }
    
    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jump);
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
}
