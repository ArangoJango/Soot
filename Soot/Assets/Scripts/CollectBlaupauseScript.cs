using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlaupauseScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventManagerScript.TriggerEvent("PlaySoundCollectCoin");
            UnlockItems.CountItem1();
            Destroy(this.gameObject);
        }
    }
}
