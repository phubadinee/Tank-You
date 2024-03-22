using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseClass
{
    private int _hp;
    private int _damage;
    private int _speed;

    public int hp{
        get{ return _hp;}
        set{ _hp = value;}
    }
    public int damage{
        get{ return _damage;}
        set{ _damage = value;}
    }
    public int speed{
        get{ return _speed;}
        set{ _speed = value;}
    }

}
