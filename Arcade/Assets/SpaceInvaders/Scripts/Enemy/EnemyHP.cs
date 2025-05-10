using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class EnemyHP : MonoBehaviour
    {
        [SerializeField] private float hp = 5;


        public void TakeDamage(float damage)
        {
            hp -= damage;
            Debug.Log("Enemy:" + hp);
            if (hp <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.AddScore(100);
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage(5);
            }
        }

    }
}