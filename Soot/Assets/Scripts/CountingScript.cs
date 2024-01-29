using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingScript : MonoBehaviour
{
    public TMPro.TMP_Text Reward;
    public TMPro.TMP_Text Collectable;

    public static int rewardnumber;
    public static int collectionnumber;

    // Start is called before the first frame update
    void Start()
    {
        Reward.text = "Coins: " + Mathf.Floor(rewardnumber);
        Collectable.text = "Collectables: " + Mathf.Floor(collectionnumber);
    }

    // Update is called once per frame
    void Update()
    {
        Reward.text = "Coins: " + Mathf.Floor(rewardnumber);
        Collectable.text = "Collectables: " + Mathf.Floor(collectionnumber);
    }
}
