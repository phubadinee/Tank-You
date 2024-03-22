using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : CharacterSelection
{
    private float moveX, moveY;
    private Rigidbody2D rb;
    private HealthBar healthBar;
    
    private int value = 0;
    AudioManager audioManager;

    public float speed;

    new void Start()
    {
        if (returnCharacter != null) {
            speed = returnCharacter.getSpeedBase();
        } else {
            speed = speed;
        }
        
        Debug.Log("Player Speed = " + speed);
        //Get component from RigidBody2D
        rb = GetComponent<Rigidbody2D>();
        value = 1;
    }
    private void Update()
    {
        //Get player's input to move player in position x and y
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (moveX * speed , rb.velocity.y);
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x , moveY * speed);
        RotatePlayer();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void RotatePlayer()
    {
        //Check player direction and rotate player's rotation to that direction;
        if(moveX > 0 && moveY > 0) { transform.rotation = Quaternion.Euler(0,0,-45); } 
        else if (moveX < 0 && moveY > 0){ transform.rotation = Quaternion.Euler(0, 0, 45); }
        else if (moveX < 0 && moveY < 0){ transform.rotation = Quaternion.Euler(0, 0, 135); }
        else if (moveX > 0 && moveY < 0) { transform.rotation = Quaternion.Euler(0, 0, -135); }
        else if (moveX == 0 && moveY < 0) { transform.rotation = Quaternion.Euler(0, 0, 180); }
        else if (moveX == 0 && moveY > 0) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        else if (moveX > 0 && moveY == 0) { transform.rotation = Quaternion.Euler(0, 0, -90); }
        else if (moveX < 0 && moveY == 0) { transform.rotation = Quaternion.Euler(0, 0, 90); }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //Destroy item when player hit item object 
        if (target.gameObject.CompareTag("Item"))
        {
            audioManager.PlaySFX(audioManager.collectItem);
            Destroy(target.gameObject);
            testPoints.instance.IncreasePoint(value);
        }
    }
}
