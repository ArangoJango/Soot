using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Museum_Enter_Trigger_Script : MonoBehaviour
{
    public GameObject InteraktionButtonE;
    public GameObject MuseumCanvas;
    private bool Interaktion = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Interaktion)
        {
            Interaktion = false;
            InteraktionButtonE.SetActive(false);
            MuseumCanvas.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteraktionButtonE.SetActive(true);
            Interaktion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteraktionButtonE.SetActive(false);
        Interaktion = false;
    }

    public void CloseMuseumCanvas()
    {
        MuseumCanvas.SetActive(false);
        Interaktion = false;
    }
}
