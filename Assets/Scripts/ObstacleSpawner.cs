using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float initialSpawnRate = 1.5f;
    public float spawnRateDecrease = 0.1f;
    public float minimumSpawnRate = 0.5f;
    public float spawnRangeX = 8f;

    private float currentSpawnRate;
    private float difficultyTimer = 0f;
    private float spawnTimer = 0f;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        // Spawna obstáculos com o tempo atual
        if (spawnTimer >= currentSpawnRate)
        {
            spawnTimer = 0f;
            SpawnObstacle();
        }

        // Aumenta a dificuldade a cada 10 segundos
        if (difficultyTimer >= 10f)
        {
            difficultyTimer = 0f;

            if (currentSpawnRate > minimumSpawnRate)
            {
                currentSpawnRate -= spawnRateDecrease;
                Debug.Log("Aumentando dificuldade. Novo spawn rate: " + currentSpawnRate);
            }
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        GameObject obj = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Aumenta velocidade de queda dos obstáculos também
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -Random.Range(3f, 6f)); // Velocidade aleatória para dar variação
        }
    }
}
