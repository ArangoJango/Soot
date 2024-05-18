using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockItems : MonoBehaviour
{
    public GameObject Unlock;
    public static int BluItem1;
    public TextMeshProUGUI Item1BlueText;
    void Update()
    {
        if (BluItem1 == 0)
        {
            Item1BlueText.text = BluItem1.ToString()+" /3";
            Unlock.gameObject.SetActive(false);
            Debug.Log(BluItem1);
        } else if (BluItem1 == 1)
        {
            Item1BlueText.text = BluItem1.ToString() + " /3";
            Debug.Log(BluItem1);
        }
        else if (BluItem1 == 2)
        {
            Item1BlueText.text = BluItem1.ToString() + " /3";
            Debug.Log(BluItem1);
        }
        else if (BluItem1 == 3)
        {
            Item1BlueText.text = BluItem1.ToString() + " /3";
            Unlock.gameObject.SetActive(true);
            Debug.Log(BluItem1);
        }
    }
    public static void CountItem1()
    {
        BluItem1++;
    }
}
