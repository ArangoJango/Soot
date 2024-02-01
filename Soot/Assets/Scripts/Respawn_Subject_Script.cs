using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Respawn_Subject_Script : MonoBehaviour
{
    public event Action<Vector3> OnRespawn;

    private Vector3 respawnPoint;

    private void Start()
    {
        // Setze den Startpunkt als Respawn-Punkt
        respawnPoint = transform.position;
    }

    public void SetRespawnPoint(Vector3 checkpointPosition)
    {
        // Setze den Respawn-Punkt auf die Position des Checkpoints
        respawnPoint = checkpointPosition;
    }

    public void Respawn()
    {
        // Führe den Respawn-Vorgang durch
        // ...

        // Informiere die Observer über den Respawn
        OnRespawn?.Invoke(respawnPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        }
    }
}