using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    [SerializeField] GameObject spawnee;
    [SerializeField] float sizeX = 1f;
    [SerializeField] float sizeY = 1f;
    [SerializeField] float spawnCooldown = 1f;

    private float spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime > 0) spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;
        }
    }

    void Spawn()
    {
        var spawn = Instantiate(spawnee);
        spawn.transform.position = transform.position;
    }

}
