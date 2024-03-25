using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void SpawnEnemy(int type)
    {
        if (type < 0 || type >= Enemies.Count)
        {
            Debug.LogError("Invalid enemy type index.");
            return;
        }

        // Choose randomly between Path1 and Path2
        Enums.Path randomPath = (Enums.Path)Random.Range(0, 2);
        List<GameObject> selectedPath = (randomPath == Enums.Path.Path1) ? Path1 : Path2;

        if (selectedPath.Count == 0)
        {
            Debug.LogError(randomPath.ToString() + " is not assigned or empty.");
            return;
        }

        // Start at the first waypoint in the list of the chosen path
        Vector3 spawnPosition = selectedPath[0].transform.position;
        Quaternion spawnRotation = selectedPath[0].transform.rotation;

        GameObject newEnemy = Instantiate(Enemies[type], spawnPosition, spawnRotation);
        Enemy script = newEnemy.GetComponent<Enemy>();

        // Set the path for the enemy
        script.SetPath(randomPath);

        // Start at the first point of the path
        script.SetTarget(selectedPath[0]);
    }

    private void SpawnTester()
    {
        // Spawn an enemy
        SpawnEnemy(0);
    }

    void Start()
    {
        InvokeRepeating("SpawnTester", 2f, 2f);
    }
}
