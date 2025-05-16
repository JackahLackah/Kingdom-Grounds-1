using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [Header("Attacking")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] picks;
    private float cooldownTimer = Mathf.Infinity;

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
