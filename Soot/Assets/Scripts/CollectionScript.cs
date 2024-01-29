using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectionScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Reward"))
            {
                CountingScript.rewardnumber++;
                gameObject.SetActive(false);
            }
             if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("BigReward"))
            {
            CountingScript.rewardnumber+=10;
            gameObject.SetActive(false);
            }

        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Collectable"))
            {
                CountingScript.collectionnumber++;
                gameObject.SetActive(false);
        }       
    }
}
