using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGame : MonoBehaviour
{
    public void StartZombie()
    {
        SceneManager.LoadScene("ZombieStart");
    }
    public void StartAlien()
    {
        SceneManager.LoadScene("AlienStart");
    }
    public void StartAsteroids()
    {
        SceneManager.LoadScene("AsteroidsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game closed");
    }
}
