using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechteckigMovingPlattform : MonoBehaviour
{
    public Transform[] positions;  // Array der Positionen, zwischen denen die Plattform sich bewegt
    public float speed = 2.0f;      // Geschwindigkeit der Plattform

    private int targetIndex = 0;

    void Update()
    {
        // Bewege die Plattform zwischen den Positionen
        MovePlatform();
    }

    void MovePlatform()
    {
        if (positions.Length == 0)
            return;

        float step = speed * Time.deltaTime;

        // Bewege zur Zielposition
        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, positions[targetIndex].position.x, step),
            Mathf.MoveTowards(transform.position.y, positions[targetIndex].position.y, step),
            transform.position.z
        );

        // �berpr�fe, ob die Plattform die Zielposition erreicht hat
        if (Vector3.Distance(transform.position, positions[targetIndex].position) < 0.01f)
        {
            // Wechsle zum n�chsten Ziel
            targetIndex = (targetIndex + 1) % positions.Length;
        }
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