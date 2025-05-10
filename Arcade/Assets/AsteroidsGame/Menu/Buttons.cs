using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Asteroids
{
    public class Buttons : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("AsteroidsGame");
        }

        public void QuitGame()
        {
            SceneManager.LoadScene("MainScene");

        }
    }
}
