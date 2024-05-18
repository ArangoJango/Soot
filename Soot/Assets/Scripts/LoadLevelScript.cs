using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadLevelScript : MonoBehaviour
{
    public GameObject Player;
    public static bool Loaded = false;
    public TMP_Text Stars, Collectables;

    void Start()
    {
        if (Loaded)
        {
            Vector3 temp = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
            Player.transform.position = temp;

            Stars.text = PlayerPrefs.GetString("Stars");
            Collection_Subject_Script.totalStars = Int32.Parse(Stars.text);
            Collectables.text = PlayerPrefs.GetString("Collectables");
            Collection_Subject_Script.totalCollected = Int32.Parse(Collectables.text);
            CountStarsGesamtScript.Starsgesamt = PlayerPrefs.GetInt("StarsGes");

            Loaded = false;
        }
    }
}
