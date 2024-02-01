using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn_Subject_Script respawn_Subject_Script = FindObjectOfType<Respawn_Subject_Script>();

            if (respawn_Subject_Script != null)
            {
                respawn_Subject_Script.SetRespawnPoint(transform.position);
            }
            this.gameObject.SetActive(false);
        }
    }
}