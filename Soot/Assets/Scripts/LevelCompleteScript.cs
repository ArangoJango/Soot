using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelCompleteScript : MonoBehaviour
{
    public GameObject LevelCompleetScreen, UIStars, UICollectable;
    // Start is called before the first frame update
    void Start()
    {
        LevelCompleetScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
            GameOverScreen();
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;
        LevelCompleetScreen.SetActive(true);
        UIStars.SetActive(false);
        UICollectable.SetActive(false);
    }

    public void GoToMainManue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        LevelCompleetScreen.SetActive(false);
        UIStars.SetActive(true);
        UICollectable.SetActive(true);
        Time.timeScale = 1;
    }
    public void RetryLvl1()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void RetryLvl2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
    public void RetryLvl3()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
    public void GoToHub()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
}