using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipable
}

public enum StatType
{
    Attack,
    Health,
    Defense,
    Critical,
}

public enum ConsumableType
{
    Health,
    Mana
}
[System.Serializable]
public class ItemDataEquipable
{
    public StatType StatType;
    public float Value;
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")] public string ItemName;
    public string Description;
    public ItemType ItemType;
    public Sprite ItemIcon;
    public int Price;
    
    [Header("Stacking")]
    public int MaxStack;
    public bool canStack;

    [Header("Consumable")]
    public ConsumableType ConsumableType;
    public int ConsumableValue;

    
    [Header("Equipable")]
    public ItemDataEquipable[] Equipables;
}
