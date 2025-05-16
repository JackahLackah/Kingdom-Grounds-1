using UnityEngine;

public class EnemyPickHolder : MonoBehaviour 
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        if(transform!=null)
        transform.localScale = enemy.localScale;
    }
}
