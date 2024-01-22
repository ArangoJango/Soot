using UnityEngine;

public class MovingPlattformDiagonalScript : MonoBehaviour
{
    public Transform startPos;  // Startposition der Plattform
    public Transform endPos;    // Endposition der Plattform
    public float speed = 2.0f;   // Geschwindigkeit der Plattform

    private bool movingToEnd = true;

    void Update()
    {
        // Bewege die Plattform zwischen den beiden Positionen
        MovePlatform();
    }

    void MovePlatform()
    {
        float step = speed * Time.deltaTime;

        if (movingToEnd)
        {
            // Bewege zur Endposition
            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, endPos.position.x, step),
                Mathf.MoveTowards(transform.position.y, endPos.position.y, step),
                transform.position.z
            );

            // Überprüfe, ob die Plattform die Endposition erreicht hat
            if (Vector3.Distance(transform.position, endPos.position) < 0.01f)
            {
                movingToEnd = false;
            }
        }
        else
        {
            // Bewege zur Startposition
            transform.position = new Vector3(
                Mathf.MoveTowards(transform.position.x, startPos.position.x, step),
                Mathf.MoveTowards(transform.position.y, startPos.position.y, step),
                transform.position.z
            );

            // Überprüfe, ob die Plattform die Startposition erreicht hat
            if (Vector3.Distance(transform.position, startPos.position) < 0.01f)
            {
                movingToEnd = true;
            }
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