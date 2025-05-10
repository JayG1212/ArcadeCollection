using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
namespace Asteroid
{
    public class Asteroid : MonoBehaviour
    {
        public GameObject[] powerUpPrefabs;
        public AsteroidSize size; // Assigned in prefab or on spawn
        public float minSpeed = 1f;
        public float maxSpeed = 3f;
        public float spinSpeed = 20f;

        public AsteroidSize Size
        {
            get;
        }
        private Rigidbody2D rb;
        private AsteroidFactory factory;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            factory = FindObjectOfType<AsteroidFactory>(); // could be cached globally if Singleton

            // Random velocity
            Vector2 direction = Random.insideUnitCircle.normalized;
            float speed = Random.Range(minSpeed, maxSpeed);
            rb.velocity = direction * speed;

            // Random rotation direction
            float rotation = Random.Range(-spinSpeed, spinSpeed);
            rb.angularVelocity = rotation;
        }

        public void DestroyAsteroid(bool destroyedByBullet)
        {
            int score = 0;
            if (destroyedByBullet) // If shot by player, Asteroid splits, the score updates, and power up may drop
            {
                if (size == AsteroidSize.Large)
                {
                    SpawnChildren(AsteroidSize.Medium, 2);

                    score = 100;
                }
                else if (size == AsteroidSize.Medium)
                {
                    SpawnChildren(AsteroidSize.Small, 2);

                    score = 50;
                }

                if (size == AsteroidSize.Small)
                {
                    score = 25;

                }
                GameMediator.Instance.TryDropPowerUp(transform);
                GameMediator.Instance.AsteroidDestroyed(score);
            }

            Destroy(gameObject);
        }

        private void SpawnChildren(AsteroidSize newSize, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 0.5f;
                factory.CreateAsteroid(newSize, (Vector2)transform.position + offset, Quaternion.identity);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                DestroyAsteroid(true);
                Destroy(other.gameObject); // destroy bullet too
            }
        }

     
    }
}