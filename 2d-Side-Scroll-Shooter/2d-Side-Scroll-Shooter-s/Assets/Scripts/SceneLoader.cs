using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndext = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndext + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
