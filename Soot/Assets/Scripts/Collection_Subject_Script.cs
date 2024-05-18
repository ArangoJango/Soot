using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Collection_Subject_Script : MonoBehaviour
{
    public event Action<int> OnStarsCollected;
    public event Action<int> OnCollectableCollected;

    public static int totalStars;
    public static int totalCollected;
        public void CollectCoin(int starsToAdd)
        {
            totalStars += starsToAdd;
            OnStarsCollected?.Invoke(totalStars);
        }
        public void CollectCollectable(int collectablesToAdd)
        {
        totalCollected += collectablesToAdd;
        OnCollectableCollected?.Invoke(totalCollected);
        }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Reward"))
        {
            int starsToAdd = 1;
            FindObjectOfType<Collection_Subject_Script>().CollectCoin(starsToAdd);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("BigReward"))
        {
            int starsToAdd = 10;
            FindObjectOfType<Collection_Subject_Script>().CollectCoin(starsToAdd);
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Collectable"))
        {
            int collectablesToAdd = 1;
            FindObjectOfType<Collection_Subject_Script>().CollectCollectable(collectablesToAdd);
            gameObject.SetActive(false);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Reward"))
        {
            CountingScript.rewardnumber++;
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("BigReward"))
        {
            CountingScript.rewardnumber += 10;
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Collectable"))
        {
            CountingScript.collectionnumber++;
            gameObject.SetActive(false);
        }
    }*/
}
