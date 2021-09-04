using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    
    public GameObject spawnerPrefab;
    public Vector2 spawnWaitTimeMinMax;
    float nextSpawnTime;

    public Vector2 spawnRotation;
    public Vector2 spawnSize;

    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float spawnWaitTime = Mathf.Lerp(spawnWaitTimeMinMax.y, spawnWaitTimeMinMax.x, Difficulty.getDifficultyPercentage());
            nextSpawnTime = Time.time + spawnWaitTime;
            float randomRotation = Random.Range(spawnRotation.x, spawnRotation.y);
            float randomScale = Random.Range(spawnSize.x, spawnSize.y);
            Vector2 randomSpawner = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + randomScale);
            GameObject spawnerObj = Instantiate(spawnerPrefab, randomSpawner, Quaternion.Euler(Vector3.forward * randomRotation));
            spawnerObj.transform.localScale = Vector2.one * randomScale;
            spawnerObj.transform.parent = transform;
        }
    }
}
    

   

