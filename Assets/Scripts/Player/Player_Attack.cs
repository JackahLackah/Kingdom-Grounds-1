using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [Header("Attacking")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] picks;
    private float cooldownTimer = Mathf.Infinity;

    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;
    public int attackDamage;

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
            //print("attack");
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
            foreach (var enemy in enemiesInRange)
            {
                if(enemy.GetComponent<Health>()!=null)
                enemy.GetComponent<Health>().TakeDamage(attackDamage);
                else
                {
                    Debug.Log("Health is null");
                }
            }
        }
        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        


        //Uses pooling
        //picks[FindFireball()].transform.position = firePoint.position;
        //picks[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }

    private int FindFireball()
    {
        for (int i = 0; i < picks.Length; i++)
        {
            if (picks[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
