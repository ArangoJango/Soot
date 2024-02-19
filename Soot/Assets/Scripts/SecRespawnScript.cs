using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecRespawnScript : MonoBehaviour
{
    public Transform Player, Checkpoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = Checkpoint.position;
        }
    }
}
