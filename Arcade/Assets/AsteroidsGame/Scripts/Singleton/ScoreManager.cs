using UnityEngine;
using TMPro;
namespace Asteroid
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int currentScore = 0;

        [SerializeField] private TMP_Text scoreText;

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

        void Start()
        {
            UpdateScoreDisplay();
        }

        public void AddScore(int amount)
        {
            currentScore += amount;
            UpdateScoreDisplay();
        }

        void UpdateScoreDisplay()
        {
            if (scoreText != null)
                scoreText.text = "Score: " + currentScore.ToString();
        }

    }
} 