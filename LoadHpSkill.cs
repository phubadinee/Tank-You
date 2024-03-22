using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadHpSkill : MonoBehaviour
{
    public GameObject[] hpSkillPrefabs;
    
    public Transform sqawnPoint;
    public TMP_Text label;

    void Start() {
        int changeValue = PlayerPrefs.GetInt("upHpSkill");
        GameObject prefab = hpSkillPrefabs[changeValue];
        GameObject clone = Instantiate(prefab, sqawnPoint.position, Quaternion.identity);
        label.text = prefab.name;
    }
}
