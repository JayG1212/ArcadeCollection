using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Factory & Spawning")]
    public AsteroidFactory factory;
    public float spawnInterval = 3f;
    public float spawnDistanceFromCenter = 12f;

    [Header("Limit")]
    public int maxAsteroids = 10;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // Only spawn if under limit
        if (timer >= spawnInterval && CountAsteroids() < maxAsteroids)
        {
            SpawnLargeAsteroid();
            timer = 0f;
        }
    }

    void SpawnLargeAsteroid()
    {
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)Camera.main.transform.position + spawnDirection * spawnDistanceFromCenter;

        Vector2 targetDirection = -spawnDirection;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        factory.CreateAsteroid(AsteroidSize.Large, spawnPosition, rotation);
    }

    int CountAsteroids()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }
}
