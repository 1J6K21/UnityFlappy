using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //sets logic to the first gameobject of type logicScript under logic 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3){

            if(gameObject.CompareTag("Coin")){
                logic.AddCoinScore(1);
                gameObject.SetActive(false);
            }else if(gameObject.CompareTag("Checkpoint")){
                logic.AddScore(1);
            }
        }
    }
}
