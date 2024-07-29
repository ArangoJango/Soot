using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameBalanceLoader : MonoBehaviour
{
    public string jsonFileName;
    public GameBalanceData gameBalanceData;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        LoadGameBalanceData();
        ApplyBalanceData();
    }

    void LoadGameBalanceData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameBalanceData = JsonUtility.FromJson<GameBalanceData>(dataAsJson);
            Debug.Log("Game balance data loaded successfully.");
        }
        else
        {
            Debug.LogError("Cannot find file: " + filePath);
        }
    }

    void ApplyBalanceData()
    {
        if (gameBalanceData == null)
        {
            Debug.LogError("Game balance data is null.");
            return;
        }

        foreach (var Movement in gameBalanceData.Movement)
        {
            Debug.Log($"Movement: {Movement.Speed}");
            // Hier die eingelesenen Daten 

            Player.GetComponent<ControllerManager>().movementSpeed = Movement.Speed;
            Player.GetComponent<ControllerManager>().jumpForce = Movement.JumpForce;
            Player.GetComponent<ControllerManager>().maxJumpHeight = Movement.MaxJumpHeight;
            Player.GetComponent<ControllerManager>().fallMultiplier = Movement.FallMultiplier;
        }
    }
}
