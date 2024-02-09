using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);  
        }
    }
}
