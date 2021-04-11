using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
