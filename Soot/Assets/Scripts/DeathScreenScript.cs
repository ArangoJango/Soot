using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreenScript : MonoBehaviour
{

    public GameObject DeathScreenMenue, UIStars, UICollectable;
    // Start is called before the first frame update
    void Start()
    {
        DeathScreenMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RespawnTrigger")
        {
            EventManagerScript.TriggerEvent("PlaySoundFallingDeath");
            GameOverScreen();
        }
        if (other.gameObject.name == "Cude (18)" || other.gameObject.name == "Cude (35)" || other.gameObject.name == "Cude (42)")
        {
            GameOverScreen();
        }
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;
        DeathScreenMenue.SetActive(true);
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
        DeathScreenMenue.SetActive(false);
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
    public void RetryLvl4()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    public void RetryLvl5()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
}
