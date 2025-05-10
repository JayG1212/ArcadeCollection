using UnityEngine;

namespace SpaceInvaders
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float spawnInterval = 3f;

        private float timer;

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                SpawnEnemy();
                timer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            int enemyTypeIndex = Random.Range(0, EnemyPool.Instance.enemyTypes.Count); // Random enemy

            GameObject enemy = EnemyPool.Instance.GetEnemy(enemyTypeIndex);
            enemy.transform.position = spawnPoints[spawnIndex].position;
            enemy.transform.rotation = Quaternion.identity;

            // Optional: tag enemy with type index if needed later
            enemy.GetComponent<EnemyTypeTracker>().typeIndex = enemyTypeIndex;
        }
    }
}