using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private int hp;
    void Start()
    {
        hp = Random.Range(3, 10);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(DelayedToDealtDamage());
        }
    }

    private void Update()
    {
        if (hp <= 0) 
        { 
            Destroy(gameObject);
        }
    }

    IEnumerator DelayedToDealtDamage()
    {
        yield return new WaitForSeconds(0.01f); // Delay for 0.02 seconds
        hp--;
    }
}
