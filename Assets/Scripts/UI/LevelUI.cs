using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Victory;
    public GameObject GameOver;
    public GameObject Hint;
    private bool isAbleToPause = true;
    private bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isAbleToPause)
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
                OnResumeClick();
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
    public void OnRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Game");
    }
    public void OnFinishEnter() 
    {
        Victory.SetActive(true);
        Time.timeScale = 0;
        isAbleToPause = false;
    }
    public void OnGameOver()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
        isAbleToPause = false;
    }
    public void GetHint(string hint)
    {
        StartCoroutine(ShowText(hint));
    }
    IEnumerator ShowText(string text)
    {
        Hint.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(5.0f);
        Hint.GetComponent<Text>().text = null;
    }
}
