using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    private float moveX, moveY;
    private Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        //Get component from RigidBody2D
        rb = GetComponent<Rigidbody2D>();
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
            Debug.Log("ä´éäÍà·Á");
            Destroy(target.gameObject);
        }
    }
}
