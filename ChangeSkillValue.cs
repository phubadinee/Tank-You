using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkillValue : MonoBehaviour
{
    public GameObject[] hpSkillValue;
    public GameObject[] damageSkillValue;
    public GameObject[] speedSkillValue;
    public int upHpSkill = 0;
    public int upDamageSkill = 0;
    public int upSpeedSkill = 0;


///////////////////////////////////////////////////////////////////////////////////////

    public void BuffHpSkillValue() 
    {
        hpSkillValue[upHpSkill].SetActive(false);
        upHpSkill = (upHpSkill + 1) % hpSkillValue.Length;
        hpSkillValue[upHpSkill].SetActive(true);
    }

    public void NerfHpSkillValue() 
    {
        hpSkillValue[upHpSkill].SetActive(false);
        upHpSkill--;
        if (upHpSkill < 0) {
            upHpSkill += hpSkillValue.Length;
        }
        hpSkillValue[upHpSkill].SetActive(true);
    }

///////////////////////////////////////////////////////////////////////////////////////
    public void BuffDamageSkillValue() 
    {
        damageSkillValue[upDamageSkill].SetActive(false);
        upDamageSkill = (upDamageSkill + 1) % damageSkillValue.Length;
        damageSkillValue[upDamageSkill].SetActive(true);
    }

    public void NerfDamageSkillValue() 
    {
        damageSkillValue[upDamageSkill].SetActive(false);
        upDamageSkill--;
        if (upDamageSkill < 0) {
            upDamageSkill += damageSkillValue.Length;
        }
        damageSkillValue[upDamageSkill].SetActive(true);
    }

///////////////////////////////////////////////////////////////////////////////////////

    public void BuffSpeedSkillValue() 
    {
        speedSkillValue[upSpeedSkill].SetActive(false);
        upSpeedSkill = (upSpeedSkill + 1) % speedSkillValue.Length;
        speedSkillValue[upSpeedSkill].SetActive(true);
    }

    public void NerfSpeedSkillValue() 
    {
        speedSkillValue[upSpeedSkill].SetActive(false);
        upSpeedSkill--;
        if (upSpeedSkill < 0) {
            upSpeedSkill += speedSkillValue.Length;
        }
        speedSkillValue[upSpeedSkill].SetActive(true);
    }
}
