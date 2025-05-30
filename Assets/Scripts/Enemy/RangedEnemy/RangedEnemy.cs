using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] picks;


    [Header("Colliders")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        picks[FindPick()].transform.position = firepoint.position;
        picks[FindPick()].GetComponent<Projectile_Enemy>().gameObject.SetActive(true);
    }

    private int FindPick()
    {
        for (int i = 0; i < picks.Length; i++)
        {
            if (!picks[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           // new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }

}
