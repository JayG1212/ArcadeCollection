using UnityEngine;

public class AsteroidFactory : MonoBehaviour
{
    [Header("Asteroid Prefabs")]
    public GameObject largeAsteroidPrefab;
    public GameObject mediumAsteroidPrefab;
    public GameObject smallAsteroidPrefab;

  
    public GameObject CreateAsteroid(AsteroidSize size, Vector2 position, Quaternion rotation)
    {
        GameObject prefabToSpawn = null;

        switch (size)
        {
            case AsteroidSize.Large:
                prefabToSpawn = largeAsteroidPrefab;
                break;
            case AsteroidSize.Medium:
                prefabToSpawn = mediumAsteroidPrefab;
                break;
            case AsteroidSize.Small:
                prefabToSpawn = smallAsteroidPrefab;
                break;
        }

        if (prefabToSpawn == null)
        {
            Debug.LogError($"Asteroid prefab for size {size} is not assigned!");
            return null;
        }

        GameObject asteroid = Instantiate(prefabToSpawn, position, rotation);
        return asteroid;
    }
}