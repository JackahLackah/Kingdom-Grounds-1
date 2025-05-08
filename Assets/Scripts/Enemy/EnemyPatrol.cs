using UnityEngine;

public class EnemyPatrol : MonoBehaviour 
{
    [Header ("Patrol Points")] 
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement")]
    [SerializeField] private float speed;
    private Vector2 initScale;
    private bool moveingLeft;

    [Header("Idling")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (moveingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            } else
            {
                DirectionChange();
            }
        }
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            moveingLeft = !moveingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        anim.SetBool("moving", true);
        idleTimer = 0;

        //Face
        enemy.localScale = new Vector2(Mathf.Abs(initScale.x) * _direction, initScale.y);

        //Move
        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y);
    }
}
