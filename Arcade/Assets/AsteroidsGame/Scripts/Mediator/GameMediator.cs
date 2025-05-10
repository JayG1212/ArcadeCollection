using Asteroid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroid
{
    /*
     Centralizes communication between objects.
     Particularly between Player, Asteroid, and Score Manager
     */
    public class GameMediator : MonoBehaviour
    {
        public GameObject[] powerUpPrefabs;
        [SerializeField] private PlayerBehaviorController playerController;

        public static GameMediator Instance { get; private set; }
        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void PlayerHitByAsteroid()
        {
            if (playerController != null)
            {
                playerController.TakeDamage(1);
            }
        }


        public void AsteroidDestroyed(int score)
        {
            ScoreManager.Instance.AddScore(score);
        }

        public void TryDropPowerUp(Transform position)
        {
            if (powerUpPrefabs == null || powerUpPrefabs.Length == 0) return;

            float dropChance = 0.5f;
            if (Random.value <= dropChance)
            {
                SpawnPowerUp(position);
            }
        }
        public void SpawnPowerUp(Transform position)
        {
            int index = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[index], position.position, Quaternion.identity);
        }
        }
    }
