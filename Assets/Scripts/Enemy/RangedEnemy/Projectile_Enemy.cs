using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private BoxCollider2D collider2D;

    private void Awake()
    {
        collider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit)
        {
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        print("hit");
        collider2D.enabled = false;
        Deactivate();
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        collider2D.enabled = true;

        float localeScaleX = transform.localScale.x;
        if (Mathf.Sign(localeScaleX) != _direction)
        {
            localeScaleX = -localeScaleX;
        }

        transform.localScale = new Vector2(localeScaleX, transform.localScale.y);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
