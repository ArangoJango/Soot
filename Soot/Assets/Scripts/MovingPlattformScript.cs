using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattformScript : MonoBehaviour
{
    public bool enableHorizontalMovement = true;  // Schalter f�r die horizontale Bewegung
    public float horizontalSpeed = 2.0f;  // Geschwindigkeit der horizontalen Bewegung
    public float horizontalRange = 5.0f;  // Bereich der horizontalen Bewegung

    public bool enableVerticalMovement = true;  // Schalter f�r die vertikale Bewegung
    public float verticalSpeed = 1.0f;  // Geschwindigkeit der vertikalen Bewegung
    public float verticalRange = 2.0f;  // Bereich der vertikalen Bewegung

    private Vector3 initialPosition;

    void Start()
    {
        // Speichern der urspr�nglichen Position der Plattform
        initialPosition = transform.position;
    }

    void Update()
    {
        // Berechnen der horizontalen Bewegung basierend auf der Zeit (falls aktiviert)
        float horizontalMovement = enableHorizontalMovement ? Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange : 0f;

        // Berechnen der vertikalen Bewegung basierend auf der Zeit (falls aktiviert)
        float verticalMovement = enableVerticalMovement ? Mathf.Sin(Time.time * verticalSpeed) * verticalRange : 0f;

        // Aktualisieren der Position der Plattform
        transform.position = new Vector3(initialPosition.x + horizontalMovement, initialPosition.y + verticalMovement, transform.position.z);
    }

    void OnCollisionStay(Collision collision)
    {
        // �berpr�fen, ob der Spieler auf der Plattform steht
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ver�ndere die relative Position des Spielers zur Plattform
            collision.transform.parent = transform;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // �berpr�fen, ob der Spieler die Plattform verl�sst
        if (collision.gameObject.CompareTag("Player"))
        {
            // Setze die relative Position des Spielers zur Plattform zur�ck
            collision.transform.parent = null;
        }
    }
}