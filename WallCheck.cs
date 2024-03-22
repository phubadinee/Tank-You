using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public Collider2D upper;

    private void OnTriggerEnter2D(Collider2D target)
    {
        target = upper;
        //Destroy item when player hit item object 
        if (target.gameObject.CompareTag("Maze Case"))
        {
            Debug.Log("·µ–°”·æß");
        }
    }
}
