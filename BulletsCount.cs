using System.Collections;
using UnityEngine;
using TMPro;

public class BulletsCount : MonoBehaviour
{
    public static BulletsCount instance;

    public TMP_Text bulletText;
    private bool IsReloading = false;
    private int currentBullets = -1;
    public int maxBullets = 10;
    public float reloadTime = 2f;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(currentBullets == -1)
            currentBullets = maxBullets;
        bulletText.text = currentBullets.ToString();
    }
    private void Update()
    {
        if (IsReloading)
            return;

        if (currentBullets <= 0)
        {
            StartCoroutine(DelayedReload());
            return;
        }
        if (currentBullets >= 19){
            currentBullets = 19;
        }
        bulletText.text = currentBullets.ToString();

    }
    public void DecreaseBullet(int v)
    {
        currentBullets -= v;
        bulletText.text = currentBullets.ToString();
    }

    IEnumerator DelayedReload()
    {
        IsReloading = true;
        Shooting.instance.outOfBullets(true);
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentBullets += maxBullets;
        IsReloading = false;
        Shooting.instance.outOfBullets(false);
    }

    public void IncreaseBullet(int ammo)
    {
        currentBullets += ammo;
        bulletText.text = currentBullets.ToString();
    }
}
