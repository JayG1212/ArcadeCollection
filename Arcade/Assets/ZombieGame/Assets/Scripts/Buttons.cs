using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   public void StartGame()
   {
        SceneManager.LoadScene("ZombieGame");  
   }

   public void QuitGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
