using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public static Shooting instance;

    private bool haveBullet = true;

    AudioManager audioManager;

    private void Awake()
    {
        instance = this;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && haveBullet)
        {
            audioManager.PlaySFX(audioManager.shoot);
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            BulletsCount.instance.DecreaseBullet(1);
        }
        else if(Input.GetButtonDown("Fire2") && haveBullet == false){
            audioManager.PlaySFX(audioManager.outBullet);
        }
    }

    public void outOfBullets(bool reloading)
    {
        if (reloading)
            haveBullet = false;
        else
            haveBullet = true;
    }
}
