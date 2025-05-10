using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders
{
    public class PlayerHP : MonoBehaviour
    {
        [SerializeField] private int hp = 3;


        public void TakeDamage(int damage)
        {
            if (hp > 0)
            {
                hp -= damage;
                GameManager.Instance.DecreaseHealth(damage);
                Debug.Log("Player:" + hp);
            }
            if (hp <= 0)
            {
                Debug.Log("Game Over");
                FindObjectOfType<GameOver>().TriggerGameOver();
                StartCoroutine(EndGame(3));

            }

        }

        private IEnumerator EndGame(int seconds)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("AlienStart");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("EBullet"))
            {
                TakeDamage(1);
            }
        }
    }
}
