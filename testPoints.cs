using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testPoints : MonoBehaviour
{
    public static testPoints instance;

    public TMP_Text pointText;
    private int currentPoints;
    private bool win;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentPoints = 0;
        win = false;
        pointText.text = currentPoints.ToString();
    }
    
    public void Update()
    {
        if (currentPoints >= 20)
        {
            win = true;
        }
    }

    public void IncreasePoint(int v)
    {
        currentPoints += v;
        pointText.text = currentPoints.ToString();
    }

    public int GetCurrentPoint(){
        return currentPoints;
    }

    public bool WinGame(){
        return win;
    }
}
