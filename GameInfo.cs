using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    public static string PlayerName {get; set;}
    public static BaseClass playerClass {get; set;}

    public static int hp {get; set;}
    public static int damage {get; set;}
    public static int speed {get; set;}
}
