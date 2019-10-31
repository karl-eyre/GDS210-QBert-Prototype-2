using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (SceneManager.GetActiveScene().name == "Menu")
            {
                Application.Quit();
            }
            else
            {
                SceneChangeToMainMenu();
            }
        }
    }

    public void SceneChangeToMainMenu()

    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void SceneChangeGame()
    {
        SceneManager.LoadScene("Oscar_Scene", LoadSceneMode.Single);
    }

    public void SceneChangeReferences()
    {
        SceneManager.LoadScene("References", LoadSceneMode.Single);
    }

    public void SceneControls()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }

    public void SceneChangeYouLose()
    {
        SceneManager.LoadScene("Lose", LoadSceneMode.Single);
    }

    public void SceneChangeYouWin()
    {
        SceneManager.LoadScene("Win", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
