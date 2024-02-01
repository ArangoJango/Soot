using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class UI_Manager_Observer : MonoBehaviour
{
    public TMPro.TMP_Text Reward;
    public TMPro.TMP_Text Collectable;

    private void Start()
    {
        Collection_Subject_Script collection_Subject_Script = FindObjectOfType<Collection_Subject_Script>();

        collection_Subject_Script.OnStarsCollected += UpdateStarUI;
        collection_Subject_Script.OnCollectableCollected += UpdateCollectionUI;
    }

    private void UpdateStarUI(int stars)
    {
        Reward.text = stars.ToString();
    }

    private void UpdateCollectionUI(int collectable)
    {
        Collectable.text = collectable.ToString();
    }

    /*public static UnityEvent onLog = new UnityEvent();

    public TMPro.TMP_Text Reward;
    public TMPro.TMP_Text Collectable;

    public static int rewardnumber;
    public static int collectionnumber;

    private IEnumerator Log()
    {
        yield return new WaitForSeconds(2f);
        Reward.text = "Coins: " + Mathf.Floor(rewardnumber);
        Collectable.text = "Collectables: " + Mathf.Floor(collectionnumber);
        onLog.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Log");
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
