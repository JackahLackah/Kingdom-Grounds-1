using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            //add iframes
            //StartCoroutine(Invunerability());
        }
        else
        {
            //dead
            if (!dead)
            {
                anim.SetTrigger("die");

                foreach(Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;
                SceneManager.LoadScene("Gameover");


            }
        }
    }
  
    
 
    
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        //IEnmuerator lets us wait
        Physics2D.IgnoreLayerCollision(7, 8, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / numberOfFlashes * 2);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / numberOfFlashes * 2);
        }
        Physics2D.IgnoreLayerCollision(7, 8, true);
    }





     

    }

