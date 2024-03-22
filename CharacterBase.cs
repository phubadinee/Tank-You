using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] public int hpBase;
    [SerializeField] public int damageBase;
    [SerializeField] public int speedBase;

    private void Start()
    {
        Debug.Log("============== Start (Charactor Base) ===============");
        // Debug.Log("Hp Base: " + hpBase);
        // Debug.Log("Damage Base: " + damageBase); 
        // Debug.Log("Speed Base: " + speedBase);  
    }

    public void setHpBase(int hpBase) {
        this.hpBase = hpBase;
    }
    public void setDamageBase(int damageBase) {
        this.damageBase = damageBase;
    }
    public void setSpeedBase(int speedBase) {
        this.speedBase = speedBase;
    }

    public int getHpBase() {
        return this.hpBase;
    }
    public int getDamageBase() {
        return this.damageBase;
    }
    public int getSpeedBase() {
        return this.speedBase;
    }
}
