using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int CurrentExp { get; private set; }
    public int MaxExp { get; private set; }
    
    public float Attack { get; private set;}
    public float Defense { get; private set;}
    public float CurrentHealth { get; private set;}
    public float MaxHealth { get; private set; }
    public float Critical { get; private set;}
    public float Gold { get; private set;}

    public void InitializePlayer(string name, int level, int maxExp, float attack, float defense,float maxHealth, float critical, float gold)
    {
        Name = name;
        Level = level;
        CurrentExp = 0;
        MaxExp = maxExp;
        Attack = attack;
        Defense = defense;
        CurrentHealth = maxHealth;
        MaxHealth = maxHealth;
        Critical = critical;
        Gold = gold;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
