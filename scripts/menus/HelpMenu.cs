using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// The help menu
/// </summary>
public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Goes back to the main menu
    /// </summary>
    public void GoBack()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
