using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class EnemySpawner : MonoBehaviour
{
    // Singleton instance
    public static EnemySpawner instance;

    // Public lists for paths and enemy prefabs
    public List<GameObject> Path1 = new List<GameObject>();
    public List<GameObject> Path2 = new List<GameObject>();
    public List<GameObject> Enemies = new List<GameObject>();

    public static EnemySpawner Get { get { return instance; } }

    // Awake function to set up singleton instance
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnEnemy(int type, Enums.Path path)
    {
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        if (path == Path.Path1)
        {
            spawnPosition = Path1[0].transform.position;
            spawnRotation = Path1[0].transform.rotation;
        }
        else if (path == Path.Path2)
        {
            spawnPosition = Path2[0].transform.position;
            spawnRotation = Path2[0].transform.rotation;
        }
        else
        {
            spawnPosition = Vector3.zero;
            spawnRotation = Quaternion.identity;
            Debug.LogError("Invalid path specified!");
            return;
        }

        var newEnemy = Instantiate(Enemies[type], spawnPosition, spawnRotation);

        var script = newEnemy.GetComponent<Enemy>();

        // set hier het path en target voor je enemy in
        script.path = path;
        script.target = Path1[1];
    }

    public GameObject RequestTarget(Enums.Path path, int index)
    {
        List<GameObject> currentPath = null;

        switch (path)
        {
            case Path.Path1:
                currentPath = Path1;
                break;
            case Path.Path2:
                currentPath = Path2;
                break;
            default:
                Debug.LogError("Invalid path specified!");
                break;
        }

        if (currentPath == null || index < 0 || index >= currentPath.Count)
        {
            Debug.LogError("Invalid path or index!");
            return null;
        }
        else
        {
            return currentPath[index];
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnTester", 1f, 1f);
    }

    private void Update()
    {

    }

    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1);
    }
}
