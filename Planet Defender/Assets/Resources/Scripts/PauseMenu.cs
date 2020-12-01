using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject pauseMenu;
    public GameObject resume;
    public GameObject restart;
    public GameObject tutorial;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(false);
        }
    }

    public void Pause(bool gameOver)
    {
        if (gameOver == false)
        {
            Time.timeScale = 0;
            playerUI.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            playerUI.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            resume.gameObject.SetActive(false);
            restart.gameObject.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        playerUI.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        tutorial.SetActive(false);
    }
}
