using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [Header("Attacking")]
    [SerializeField] private float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    bool attack = false;

    private Animator anim;
    private PlayerNewMovement playerNewMovement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerNewMovement = GetComponent<PlayerNewMovement>();
    }

    private void Update()
    {
        GetInstanceID();
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown)
        {
            Attack();
            print("attack");
        }
        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        
        //Uses pooling

    }

    
}
