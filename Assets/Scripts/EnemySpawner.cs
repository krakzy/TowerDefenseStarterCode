using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;

    private int ufoCounter = 0;

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

    public void StartWave(int number)

    {


        // reset counter 

        ufoCounter = 0;



        switch (number)

        {

            case 1:

                InvokeRepeating("StartWave1", 1f, 1.5f);

                break;



        }

    }

    public void StartWave1()

    {

        ufoCounter++;

        // leave some gaps 

        if (ufoCounter % 6 <= 1) return;



        if (ufoCounter < 30)

        {

            SpawnEnemy(0);

        }
        else

        {

            // the last Enemy will be level 2 

            SpawnEnemy(1);

        }



        if (ufoCounter > 30)
        {
            CancelInvoke("StartWave1");
            // Access the instance of GameManager and call the EndWave method
            GameManager.instance.EndWave();
        }


    }

    void Start()
    {
        
    }
}
