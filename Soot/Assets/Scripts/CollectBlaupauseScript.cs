using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBlaupauseScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnlockItems.CountItem1();
            Destroy(this.gameObject);
        }
    }
}
