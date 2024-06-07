using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LagerAuswahlScript : MonoBehaviour
{
    public GameObject KreuzItem1, AuswahlJaNein;
    private bool istAktiviert = false;
    public void Start()
    {
        KreuzItem1.SetActive(true);
    }
    /*public void ToggleItem1()
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
    }*/

    public void AuswahlJa()
    {
        KreuzItem1.SetActive(false);
        AuswahlJaNein.SetActive(false);
        EventManagerScript.TriggerEvent("PlaySoundEquip");
    }
    public void AuswahlNein()
    {
        AuswahlJaNein.SetActive(false);
        KreuzItem1.SetActive(true);
    }
    public void AuswahlMenü()
    {
        AuswahlJaNein.SetActive(true);
    }
}
