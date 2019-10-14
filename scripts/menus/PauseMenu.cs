using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0;
    }
    /// <summary>
    /// Resumes the paused game
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Quits the paused game
    /// </summary>
    public void QuitGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
