using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_to_Kap2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject InteractionButton;
    public GameObject UI_Info;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InteractionButton.SetActive(true);
        }
    }

    private void Update()
    {
        if(InteractionButton.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E) && Player.GetComponent<PlayerGlidingScript>().enabled == true)
        {
            SceneManager.LoadScene(5);
        }
        else if (InteractionButton.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E) && Player.GetComponent<PlayerGlidingScript>().enabled == false)
        {
            UI_Info.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionButton.SetActive(false);
        UI_Info.SetActive(false);
    }
}
