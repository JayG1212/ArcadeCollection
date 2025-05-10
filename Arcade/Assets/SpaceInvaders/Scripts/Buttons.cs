using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceInvaders
{
    public class Buttons : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene("AlienGame");
        }

        public void QuitGame()
        {
            SceneManager.LoadScene("MainScene");
           
        }
    }
}