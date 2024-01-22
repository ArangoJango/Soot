using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KreisMovingPlattformScript : MonoBehaviour
{
    public Transform center;       // Zentrum des Kreises
    public float radius = 3.0f;     // Radius des Kreises
    public float speed = 2.0f;      // Geschwindigkeit der Bewegung

    private float angle = 0.0f;

    void Update()
    {
        MoveInCircle();
    }

    void MoveInCircle()
    {
        // Berechne die neue Position auf dem Kreis
        float x = center.position.x + Mathf.Cos(angle) * radius;
        float y = center.position.y + Mathf.Sin(angle) * radius;

        // Setze die Position für die Plattformen
        transform.position = new Vector3(x, y, transform.position.z);

        // Aktualisiere den Winkel für die nächste Frame
        angle += speed * Time.deltaTime;

        // Wenn der Winkel den vollen Kreis umrundet hat, setze ihn zurück
        if (angle >= 360.0f)
        {
            angle -= 360.0f;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        // Überprüfen, ob der Spieler auf der Plattform steht
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verändere die relative Position des Spielers zur Plattform
            collision.transform.parent = transform;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Überprüfen, ob der Spieler die Plattform verlässt
        if (collision.gameObject.CompareTag("Player"))
        {
            // Setze die relative Position des Spielers zur Plattform zurück
            collision.transform.parent = null;
        }
    }
}