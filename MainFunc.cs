using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFunc : MonoBehaviour
{
    public int hpPlayer = 0;
    public int damagePlayer = 0;
    public int speedPlayer = 0;
    // Start is called before the first frame update

    public void hpUpSkillPress() {
        hpPlayer += 1;
    }
    public void damageUpSkillPress() {
        damagePlayer += 1;
    }
    public void speedUpSkillPress() {
        speedPlayer += 1;
    }
}
