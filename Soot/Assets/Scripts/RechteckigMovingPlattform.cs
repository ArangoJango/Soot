using System.Collections;
using UnityEngine;

public class RechteckigMovingPlattform : MonoBehaviour
{
    public Transform startPosition;
    public float width = 5.0f; // Breite der Plattform
    public float height = 2.0f; // Höhe der Plattform
    public float speed = 2.0f;
    public float delay = 1.0f;
    public bool moveRight = true; // Richtung der Bewegung

    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;

    void Start()
    {
        CalculateWaypoints();
        StartCoroutine(MovePlatform());
    }

    void CalculateWaypoints()
    {
        waypoints = new Vector3[5];
        waypoints[0] = startPosition.position;

        if (moveRight)
        {
            waypoints[1] = startPosition.position + new Vector3(width, 0f, 0f);
            waypoints[2] = startPosition.position + new Vector3(width, height, 0f);
            waypoints[3] = startPosition.position + new Vector3(0f, height, 0f);
            waypoints[4] = startPosition.position;
        }
        else
        {
            waypoints[1] = startPosition.position - new Vector3(width, 0f, 0f);
            waypoints[2] = startPosition.position - new Vector3(width, height, 0f);
            waypoints[3] = startPosition.position - new Vector3(0f, height, 0f);
            waypoints[4] = startPosition.position;
        }
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.01f)
            {
                if (moveRight)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                    if (currentWaypointIndex == 0)
                        yield return new WaitForSeconds(delay);
                }
                else
                {
                    currentWaypointIndex = (currentWaypointIndex - 1 + waypoints.Length) % waypoints.Length;
                    if (currentWaypointIndex == waypoints.Length - 1)
                        yield return new WaitForSeconds(delay);
                }
            }

            yield return null;
        }
    }
}