using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private GameObject[] objects;

    private TimeManager timeManager;



    public float nextSpawnTime=0f;
    
    void Start()
    {
        spawnPositions[0].gameObject.name = "Test";
        
        timeManager = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            nextSpawnTime += spawnRate;
            SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);

        }
    }

    private void SpawnObject(GameObject objectToSpawn, Transform newTransform)
    {
        Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0, objects.Length);
    }

}
