using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_Script : MonoBehaviour
{
    public GameObject PauseMenue;
    void Start()
    {
        PauseMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenue.SetActive(true);
        }
    }

    public void GoToMainManue()
    {
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        PauseMenue.SetActive(false);
        Time.timeScale = 1;
    }
}
