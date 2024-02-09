using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    //private Vector2 rbReflect;

    [SerializeField]
    private GameObject bulletParticles;

    private void Start()
    {
        //Get component and set bullet speed
        rb = GetComponent<Rigidbody2D>();   
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //Destroy bullet object when it hit walls
        if (target.gameObject.CompareTag("Maze Case"))
        {
            Destroy(gameObject);
        }
    }

}
