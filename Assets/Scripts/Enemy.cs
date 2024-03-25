using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float health = 10f;
    public int points = 1;
    public Enums.Path path { get; private set; }
    public List<GameObject> waypoints;
    private int currentWaypointIndex = 0;

    // Set the path for the enemy
    public void SetPath(Enums.Path newPath)
    {
        path = newPath;
        waypoints = (path == Enums.Path.Path1) ? EnemySpawner.Instance.Path1 : EnemySpawner.Instance.Path2;
    }

    public void Damage(int damage)
    {
        // Lower the health value 
        health -= damage;

        // Check if health is smaller or equal to zero 
        if (health <= 0)
        {
            // Destroy the game object 
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTarget(waypoints[currentWaypointIndex]);
    }

    // Set the target for the enemy
    public void SetTarget(GameObject newTarget)
    {
        currentWaypointIndex = waypoints.IndexOf(newTarget);
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints == null || waypoints.Count == 0)
            return;

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, step);

        // Check if the enemy has reached the target
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {
            // Go to the next waypoint if available
            if (currentWaypointIndex < waypoints.Count - 1)
            {
                currentWaypointIndex++;
                SetTarget(waypoints[currentWaypointIndex]);
            }
            else
            {
                // If all waypoints are reached, destroy the enemy
                Destroy(gameObject);
            }
        }
    }
}
