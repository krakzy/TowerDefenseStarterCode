using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class Enemy : MonoBehaviour
{
   public float speed = 1f; 

    public float health = 10f; 

    public int points = 1; 

    public Enums.Path path { get; set; } 

    public GameObject target { get; set; } 

    private int pathIndex = 1; 

    public void Start()
    {

    } 

void Update() 
{ 
    if (target != null)
    {
        float step = speed * Time.deltaTime; 

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step); 

        // check how close we are to the target 

        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f) 
        { 
            // if close, request a new waypoint 
            pathIndex++;
            target = EnemySpawner.instance.RequestTarget(path, pathIndex);

            if (target == null) 
            { 
                Destroy(gameObject); 
            } 
        } 
    }
}
 
    
}
