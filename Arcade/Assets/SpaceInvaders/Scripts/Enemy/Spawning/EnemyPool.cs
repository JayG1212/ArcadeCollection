using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class EnemyPool : MonoBehaviour
    {
        [System.Serializable]
        public class EnemyTypePool
        {
            public GameObject prefab;
            public int poolSize = 10;
            [HideInInspector] public Queue<GameObject> pool = new Queue<GameObject>();
        }

        public List<EnemyTypePool> enemyTypes;

        public static EnemyPool Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            foreach (var type in enemyTypes)
            {
                for (int i = 0; i < type.poolSize; i++)
                {
                    GameObject enemy = Instantiate(type.prefab);
                    enemy.SetActive(false);
                    type.pool.Enqueue(enemy);
                }
            }
        }

        public GameObject GetEnemy(int index)
        {
            var type = enemyTypes[index];

            if (type.pool.Count == 0)
            {
                GameObject newEnemy = Instantiate(type.prefab);
                newEnemy.SetActive(false);
                return newEnemy;
            }

            GameObject pooledEnemy = type.pool.Dequeue();
            pooledEnemy.SetActive(true);
            return pooledEnemy;
        }

        public void ReturnEnemy(GameObject enemy, int index)
        {
            enemy.SetActive(false);
            enemyTypes[index].pool.Enqueue(enemy);
        }
    }
}