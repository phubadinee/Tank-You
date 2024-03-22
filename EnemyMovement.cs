using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static EnemyMovement instance;

    private float moveX, moveY, speed;
    private Rigidbody2D rb;
    private int randomRL = 0, nowZ = 0;
    private bool ifElseConditionExecuted = false;


    public float speedInput;
    public GameObject upper, right, left;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Get component from RigidBody2D
        rb = GetComponent<Rigidbody2D>();
        moveX = 1; moveY = 1;
        speed = speedInput;

        rb.velocity = new Vector2(rb.velocity.x, moveY * speed);
    }

    public void IncreaseSpeed(int value)
    {
        speedInput += value;
    }

    private void Update()
    {
        
        
        if (transform.eulerAngles.z == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0, moveY * speed);
        }
        else if(transform.eulerAngles.z == 90 || transform.eulerAngles.z == -270)
        {
            rb.velocity = new Vector2(moveX * speed * -1, rb.velocity.y * 0);
        }
        else if (transform.eulerAngles.z == 180 || transform.eulerAngles.z == -90)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0, moveY * speed * -1);
        }
        else if (transform.eulerAngles.z == 270 || transform.eulerAngles.z == -90)
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y * 0);
        }


        if (speed == 0 && !ifElseConditionExecuted)
        {
            StartCoroutine(DelayedIfElseCondition());
        } 
        else if (speed != 0)
        {
            ifElseConditionExecuted = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Maze Case"))
        {
            speed = 0;
            randomRL = Random.Range(0, 2);
            if (upper.activeSelf)
            {
                StartCoroutine(DelayedExecution(upper, right));
            }
            else if (right.activeSelf)
            {
                StartCoroutine(DelayedExecution(right, left));
            }
            else if (left.activeSelf)
            {
                left.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {

        if (target.gameObject.CompareTag("Enemy"))
        {
            int randomT = Random.Range(1, 4);
            StartCoroutine(DelayedRotating(right, 90 * randomT));
        }
    }

    IEnumerator DelayedExecution(GameObject toDisable, GameObject toEnable)
    {
        toDisable.SetActive(false); // Disable the object
        yield return new WaitForSeconds(0.02f); // Delay for 0.02 seconds
        toEnable.SetActive(true); // Enable the next object after the delay
    }

    IEnumerator DelayedRotating(GameObject toDisable, int toRotate)
    {
        yield return new WaitForSeconds(0.02f); // Delay for 0.02 seconds
        nowZ += toRotate;
        if (nowZ >= 360) { nowZ -= 360; }
        transform.rotation = Quaternion.Euler(0, 0, nowZ);
        toDisable.SetActive(false); // Disable the object
    }

    IEnumerator DelayedToEnableUpper()
    {
        yield return new WaitForSeconds(0.02f); // Delay for 0.02 seconds
        upper.SetActive(true); // Disable the object
    }

    IEnumerator DelayedIfElseCondition()
    {
        ifElseConditionExecuted = true; // Prevents the coroutine from being called repeatedly
        yield return new WaitForSeconds(0.3f); // Delay for 0.3 seconds

        if (!right.activeSelf && !left.activeSelf)
        {
            StartCoroutine(DelayedRotating(right, 180));
        }
        else if (right.activeSelf && !left.activeSelf)
        {
            StartCoroutine(DelayedRotating(right, 270));
        }
        else if (left.activeSelf && !right.activeSelf)
        {
            StartCoroutine(DelayedRotating(left, 90));
        }
        StartCoroutine(DelayedToEnableUpper());
        speed = speedInput;
    }
}
