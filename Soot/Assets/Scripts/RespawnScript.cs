using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
   private Transform Player;
    public Transform Spawnpoint;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.transform;
            Player.position = Spawnpoint.position;
        }
    }
}
