using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject coinPipe;
    public GameObject pipe;
    public float spawnRate = 1.5F;
    public float timer = 0;
    float heightOffset = 0.5F;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }else{
            SpawnPipe();
        }
    }

    void SpawnPipe(){

        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        var rand = new System.Random();

        Instantiate((rand.Next(0,4) == 0) ? coinPipe : pipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
        timer = 0;
        
    }
}
