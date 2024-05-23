using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Checkpoint_Script : MonoBehaviour
{
    public GameObject SaveUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveLoadSystemScript.ActivateE = true;
            SaveUI.SetActive(true);
            Respawn_Subject_Script respawn_Subject_Script = FindObjectOfType<Respawn_Subject_Script>();

            if (respawn_Subject_Script != null)
            {
                respawn_Subject_Script.SetRespawnPoint(transform.position);
            }
            //this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        SaveUI.SetActive(false);
        SaveLoadSystemScript.ActivateE = false;
    }
}