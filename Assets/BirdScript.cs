using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public bool birdIsAlive = true;

    public Sprite idleSprite;
    public Sprite upSprite;
    private SpriteRenderer spriteRenderer;
    public LogicScript logic;



    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //sets logic to the first gameobject of type logicScript under logic
        logic.StartNums();

        spriteRenderer = GetComponent<SpriteRenderer>(); //set the renderer to the renderer of the bird(will render which sprite is picked)

        spriteRenderer.sprite = idleSprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive){
            if(Input.GetKeyDown(KeyCode.Space)){
                myRigidBody.velocity = Vector2.up * flapStrength;
                spriteRenderer.sprite = upSprite;
            }else if(Input.GetKeyUp(KeyCode.Space)){
                spriteRenderer.sprite = idleSprite;
            }
            

            if(transform.position.y > -4 || transform.position.y < -6){
                logic.GameOver();
                birdIsAlive = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        logic.GameOver();
        birdIsAlive = false;
    }
}
