using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace SpaceInvaders
{
    public class GameOver : MonoBehaviour
    {
        [Header("Fade & UI")]
        public Image fadeImage;
        public TMP_Text gameOverText;

        [Header("Optional Settings")]
        public bool freezeTime = true;

        [Header("Player Components")]
        public GameObject player;

        private bool isGameOver = false;
        private float fadeDuration = 1.5f;

        void Start()
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(0, 0, 0, 0);
            gameOverText.gameObject.SetActive(false);
        }

        public void TriggerGameOver()
        {
            if (isGameOver) return;
            isGameOver = true;

            // Disable player input or components
            if (player != null)
            {
                var move = player.GetComponent<PlayerMove>();
                var shoot = player.GetComponent<PlayerShoot>();
                var input = player.GetComponent<InputHandler>();

                if (move) move.enabled = false;
                if (shoot) shoot.enabled = false;
                if (input) input.enabled = false;
            }

            if (freezeTime) Time.timeScale = 0f;

            StartCoroutine(FadeAndShowGameOver());
        }

        private IEnumerator FadeAndShowGameOver()
        {
            float timer = 0f;

            while (timer < fadeDuration)
            {
                float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);
                timer += Time.unscaledDeltaTime;
                yield return null;
            }

            fadeImage.color = Color.black;
            gameOverText.gameObject.SetActive(true);
        }
    }
}