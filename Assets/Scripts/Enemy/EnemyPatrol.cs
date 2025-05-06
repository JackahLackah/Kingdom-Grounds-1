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

    private void MoveInDirection(int _direction)
    {


        enemy.position = new Vector2(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y);
    }
}
