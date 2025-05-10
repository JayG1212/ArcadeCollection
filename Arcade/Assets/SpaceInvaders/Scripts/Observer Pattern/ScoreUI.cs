using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvaders
{
    public class ScoreUI : MonoBehaviour, IObserverUI
    {
        [SerializeField] private TMP_Text scoreText;

        private void Start()
        {
            GameManager.Instance.AddObserver(this);
            UpdateScore(GameManager.Instance.GetScore());
        }

        public void OnGameStateChanged(int score, int health)
        {
            UpdateScore(score);
        }

        private void UpdateScore(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }

        private void OnDestroy()
        {
            GameManager.Instance.RemoveObserver(this);
        }
    }
}