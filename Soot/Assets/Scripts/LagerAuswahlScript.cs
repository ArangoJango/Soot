using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagerAuswahlScript : MonoBehaviour
{
    public GameObject KreuzItem1;
    private bool istAktiviert = false;

    public void ToggleItem1()
    {
        istAktiviert = !istAktiviert; // Toggle den Wert

        if (istAktiviert)
        {
            KreuzItem1.SetActive(true);
        }
        else
        {
            KreuzItem1.SetActive(false);
        }
    }
}
