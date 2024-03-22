using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSkill : MonoBehaviour
{

    [SerializeField] private int hpValue = 10;
    [SerializeField] private int damageValue = 10;
    [SerializeField] private int speedValue = 10;
    [SerializeField] private ResourceBarTracker hp_resourceBarTracker;
    [SerializeField] private ResourceBarTracker damage_resourceBarTracker;
    [SerializeField] private ResourceBarTracker speed_resourceBarTracker;
    [Space]
    [SerializeField] private CharacterBase characterValue;


    public void ChangeHp() {
        bool successfulCast = hp_resourceBarTracker.HpChangeResourceByAmount(hpValue);

        // if (successfulCast) {
        //     Debug.Log("Cast successful");
        // } else {
        //     Debug.Log("Cast failed due to lack of Mana");
        // }
            
    }

    public void ChangeDamage() {
        bool successfulCast = damage_resourceBarTracker.DamageChangeResourceByAmount(damageValue);

        // if (successfulCast) {
        //     Debug.Log("Cast successful");
        // } else {
        //     Debug.Log("Cast failed due to lack of Mana");
        // }
            
    }

    public void ChangeSpeed() {
        bool successfulCast = speed_resourceBarTracker.SpeedChangeResourceByAmount(speedValue);

        // if (successfulCast) {
        //     Debug.Log("Cast successful");
        // } else {
        //     Debug.Log("Cast failed due to lack of Mana");
        // }
            
    }
}
