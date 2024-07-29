using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelCompleteScript : MonoBehaviour
{
    public GameObject LevelCompleetScreen, UIStars, UICollectable;
    public TextMeshProUGUI StarText, CollectedStars, CollectedTExt, CollectedCollectables;
    
    public GameObject Cutscene;
    public float destroyTime = 5f;
    public bool CutsceneAfterLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        LevelCompleetScreen.SetActive(false);
        Cutscene.SetActive(false);
        CollectedStars.text = System.Convert.ToString(0);
        CollectedCollectables.text = System.Convert.ToString(0);
    }

    private void OnTriggerEnter(Collider other)
    {
            GameOverScreen();
            CollectedStars.text = StarText.text;
            CollectedCollectables.text = CollectedTExt.text;
            CountStarsGesamtScript.Starsgesamt += Convert.ToInt32(StarText.text); 
    }

    public void GameOverScreen()
    {
        EventManagerScript.TriggerEvent("PlaySoundLevelComplete");
        EventManagerScript.TriggerEvent("PlaySoundCountUp");
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
        if (CutsceneAfterLevel)
        {
            Time.timeScale = 1;
            StartCoroutine(DestroyObject());
        }
        else
        {
            SceneManager.LoadScene(4);
            Time.timeScale = 1;
        }
    }
    IEnumerator DestroyObject()
    {
        Cutscene.SetActive(true);
        yield return new WaitForSeconds(destroyTime);
        SceneManager.LoadScene(4);
        //Time.timeScale = 1;
    }
}