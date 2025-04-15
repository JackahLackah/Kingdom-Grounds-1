using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [Header("Attacking")]
    bool attack = false;
    float timeBetweenAttack, timeSinceAttack;

    private void Awake()
    {
       
    }

    private void Update()
    {
        GetInstanceID();
        Attack();
    }

    void GetInputs()
    {
        attack = Input.GetMouseButtonDown(0);
    }
    void Attack()
    {
        timeSinceAttack += Time.deltaTime;
        if(attack && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;
        }
    }


    
}
