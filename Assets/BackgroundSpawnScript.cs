using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundSpawnScript : MonoBehaviour
{
    public GameObject darkBack; //night background
    public GameObject lightBack; //day background
    public float spawnRate = 4.5F;
    public float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate( true ? lightBack : darkBack, new Vector3(-1.35F, -5, 10), transform.rotation);
        Instantiate( true ? lightBack : darkBack, new Vector3(-0.1F, -5, 10), transform.rotation);
        Instantiate( true ? lightBack : darkBack, new Vector3(1.15F, -5, 10), transform.rotation);
        Instantiate( true ? lightBack : darkBack, new Vector3(2.4F, -5, 10), transform.rotation);
        SpawnBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }else{
            SpawnBackground();
        }
    }

    void SpawnBackground(){
        Instantiate( true ? lightBack : darkBack, new Vector3(transform.position.x, transform.position.y, 10), transform.rotation);
        timer = 0;
        
    }
}
