using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ResourceBarTracker : MonoBehaviour
{   
    public int hpCurrent;
    public int damageCurrent;
    public int speedCurrent;

    [Header("Core Settings")]
    [SerializeField]  private Image bar1;
    [SerializeField]  private Image bar2;
    [SerializeField]  private Image bar3;

    [SerializeField]  private int hpMax = 100;    
    [SerializeField]  private int damageMax = 100;
    [SerializeField]  private int speedMax = 100;
    [Space] 
    [SerializeField]  private bool overkillPossible; 

    private CharacterBase selectedCharacter;
    public static ResourceBarTracker Instance;

    private void Start() {
        Debug.Log("============== Start (Resource Bar) ===============");
        UpdateBars();
        
    }

    private void Awake()
    {
        Instance = this; // Set the singleton instance
    }


    public int getHpSelected(){
        return hpCurrent;
    }
    public int getDamageSelected(){
        return damageCurrent;
    }
    public int getSpeedSelected(){
        return speedCurrent;
    }


    public void UpdateBars()
    {
        if (CharacterSelection.returnCharacter != null)
        {
            selectedCharacter = CharacterSelection.returnCharacter;
            hpCurrent = selectedCharacter.getHpBase();
            damageCurrent = selectedCharacter.getDamageBase();
            speedCurrent = selectedCharacter.getSpeedBase();

            Debug.Log("HP ->" + hpCurrent);
            Debug.Log("Damage ->" + damageCurrent);
            Debug.Log("Speed ->" + speedCurrent);

            bar1.fillAmount = (float)hpCurrent / hpMax;
            bar2.fillAmount = (float)damageCurrent / damageMax;
            bar3.fillAmount = (float)speedCurrent / speedMax;
        }
    
    }

    private void HpUpdateBar() {
        if(hpMax <=0) {
            bar1.fillAmount = 0;
            return;
        }
        float fillAmount = (float) hpCurrent / hpMax;
        bar1.fillAmount = fillAmount;
        // Debug.Log("Update Hp");
    }

    public bool HpChangeResourceByAmount(int amount) {
        if (!overkillPossible && hpCurrent + amount < 0){
            return false;
        }
        
        if (TotalPoint.instance.getGameTotalPoints() >= 50){
            TotalPoint.instance.DecreaseTotalPoints(50);
            hpCurrent += amount;
            hpCurrent = Mathf.Clamp(hpCurrent, 0, hpMax);
            bar1.fillAmount = (float) hpCurrent / hpMax;
            Debug.Log("Update Hp : " + hpCurrent);
            
        }
        return true;
    }
    ///////////////////////////////////////
    private void DamageUpdateBar() {
        if(damageMax <=0) {
            bar2.fillAmount = 0;
            return;
        }
        float fillAmount = (float) damageCurrent / damageMax;

        bar2.fillAmount = fillAmount;
        // Debug.Log("Update Damage");
        
    }

    public bool DamageChangeResourceByAmount(int amount) {
        if (!overkillPossible && damageCurrent + amount < 0){
            return false;
        }
           
        if (TotalPoint.instance.getGameTotalPoints() >= 50){
            TotalPoint.instance.DecreaseTotalPoints(50);
            damageCurrent += amount;
            damageCurrent = Mathf.Clamp(damageCurrent, 0, damageMax);
            bar2.fillAmount = (float) damageCurrent / damageMax;

            Debug.Log("Update Damage : " + damageCurrent);
            
        }
        return true;
    }
    // ///////////////////////////////////////////
    private void SpeedUpdateBar() {
        if(speedMax <=0) {
            bar3.fillAmount = 0;
            return;
        }
        float fillAmount = (float) speedCurrent / speedMax;

        bar3.fillAmount = fillAmount;
        // Debug.Log("Update Speed");
    }

    public bool SpeedChangeResourceByAmount(int amount) {
        if (!overkillPossible && speedCurrent + amount < 0){
            return false;
        }
           
        if (TotalPoint.instance.getGameTotalPoints() >= 50){
            TotalPoint.instance.DecreaseTotalPoints(50);
            speedCurrent += amount;
            speedCurrent = Mathf.Clamp(speedCurrent, 0, speedMax);
            bar3.fillAmount = (float) speedCurrent / speedMax;
            Debug.Log("Update Speed : " + speedCurrent);
        
        }
        return true;
    }

}
