using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlattormScript : MonoBehaviour
{
    public float boostForce = 10f; // The force with which the platform boosts the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Apply the boost force to the player's Rigidbody
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z); // Reset vertical velocity
                playerRb.AddForce(Vector3.up * boostForce, ForceMode.Impulse);
            }
        }
    }
}