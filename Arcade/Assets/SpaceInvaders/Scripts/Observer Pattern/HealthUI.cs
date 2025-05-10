using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvaders
{
    public class HealthUI : MonoBehaviour, IObserverUI
    {
        [SerializeField] private TMP_Text healthText;

        private void Start()
        {
            GameManager.Instance.AddObserver(this);
            UpdateHealth(GameManager.Instance.GetHealth());
        }

        public void OnGameStateChanged(int score, int health)
        {
            UpdateHealth(health);
        }

        private void UpdateHealth(int health)
        {
            healthText.text = "HP: " + health.ToString();
        }

        private void OnDestroy()
        {
            GameManager.Instance.RemoveObserver(this);
        }
    }
}