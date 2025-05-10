using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

    public class PlayerHPManager : MonoBehaviour
    {
        public static PlayerHPManager Instance { get; private set; }

        public int maxHealth = 3;
        private int currentHealth;

        [SerializeField] private TMP_Text healthText;
        public int CurrentHealth => currentHealth;

        void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        void Start()
        {
            currentHealth = maxHealth;
            UpdateHealthUI();
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                Debug.Log("Player Died!");
                // Add player death handling here
                SceneManager.LoadScene("AsteroidsMenu");
            }
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthUI();
        }

        void UpdateHealthUI()
        {
            if (healthText != null)
                healthText.text = "Health: " + currentHealth;
        }
    }

}