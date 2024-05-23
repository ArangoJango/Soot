using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SaveLoadSystemScript : MonoBehaviour
{
    public GameObject Player;
    public float PlayerX, PlayerY, PlayerZ;
    public int SceneNumber, StarsGesString;

    public TMP_Text Stars, Collectables;
    public string StarsString, CollectablesString;

    public static bool ActivateE=false;

    public static void StartSave()
    {
        SaveLoadSystemScript saveLoadSystem = new SaveLoadSystemScript();
        saveLoadSystem.SaveData();
    }

    public void SaveData()
    {

        //actual Saving
        PlayerPrefs.SetFloat("PlayerX", Player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", Player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", Player.transform.position.z);

        PlayerPrefs.SetInt("SceneNumber", SceneManager.GetActiveScene().buildIndex);
        
        PlayerPrefs.SetString("Stars", Stars.text);
        PlayerPrefs.SetString("Collectables", Collectables.text);
        PlayerPrefs.SetInt("StarsGes", CountStarsGesamtScript.Starsgesamt);
        
        /* Savetypes
        PlayerPrefs.SetFloat();
        PlayerPrefs.SetString();
        PlayerPrefs.SetInt();
        */
    }

    public void LoadData()
    {
        LoadLevelScript.Loaded = true;
        PlayerX = PlayerPrefs.GetFloat("PlayerX");
        PlayerY = PlayerPrefs.GetFloat("PlayerY");
        PlayerZ = PlayerPrefs.GetFloat("PlayerZ");

        SceneNumber = PlayerPrefs.GetInt("SceneNumber");

        StarsString = PlayerPrefs.GetString("Stars");
        CollectablesString = PlayerPrefs.GetString("Collectables");
        StarsGesString = PlayerPrefs.GetInt("StarsGes");

        SceneManager.LoadScene(SceneNumber);
        /* Loadtypes
        PlayerPrefs.GetFloat();
        PlayerPrefs.GetString();
        PlayerPrefs.GetInt();
        */
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Update()
    {
        if(ActivateE && Input.GetKeyDown(KeyCode.E))
        {
            SaveData();
        }
    }
}
