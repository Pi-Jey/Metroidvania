using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public GameObject PauseMenu;
        
    private bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                isPaused = false;
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void OnResumeClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnExitClick()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
