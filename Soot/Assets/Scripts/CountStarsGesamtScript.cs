using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountStarsGesamtScript : MonoBehaviour
{
    public static int Starsgesamt;
    public TextMeshProUGUI StarUI;
    private void Update()
    {
        StarUI.text = Starsgesamt.ToString();
    }
}
