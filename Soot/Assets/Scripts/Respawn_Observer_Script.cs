using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Observer_Script : MonoBehaviour
{
    private Respawn_Subject_Script respawn_Subject_Script;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Player");
        respawn_Subject_Script = FindObjectOfType<Respawn_Subject_Script>();

        if (respawn_Subject_Script != null)
        {
            respawn_Subject_Script.OnRespawn += HandleRespawn;
        }
    }

    private void HandleRespawn(Vector3 respawnPoint)
    {
        Player.transform.position = respawnPoint;
    }
}