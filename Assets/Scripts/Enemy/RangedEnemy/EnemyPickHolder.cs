using UnityEngine;

public class EnemyPickHolder : MonoBehaviour 
{
    [SerializeField] private Transform enemy;

    private void Update()
    {
        transform.localScale = enemy.localScale;
    }
}
