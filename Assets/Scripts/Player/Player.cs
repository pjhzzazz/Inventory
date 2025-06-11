using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class InventoryItem
{
    public ItemData Data;
    public int Quantity;
    public bool Equipped;

    public InventoryItem(ItemData data, int quantity = 1)
    {
        Data = data;
        Quantity = quantity;
        Equipped = false;
    }
}
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

    public List<Item> Inventory { get; private set; }
    private List<Item> equippedItems;
    public Action addItem;
    [Header("Debug")]
    public bool DebugMode = true;
    
    private void Awake()
    {
        Inventory = new List<Item>();
    }

    private void Update()
    {
        if (!DebugMode) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRandomItem();
        }
    }

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

    public void AddItem(ItemData itemData, int stackSize = 1)
    {
        if (itemData.canStack)
        {
            // 기존에 같은 아이템이 있는지 확인
            Item existingItem = Inventory.Find(item => item.itemData == itemData && item.stackSize < item.MaxStack);
            if (existingItem != null)
            {
                int addAmount = Mathf.Min(stackSize, existingItem.MaxStack - existingItem.stackSize);
                existingItem.stackSize += addAmount;
                stackSize -= addAmount;
            }
        }
        while (stackSize > 0)
        {
            int currentStack = itemData.canStack ? Mathf.Min(stackSize, itemData.MaxStack) : 1;
            Inventory.Add(new Item(itemData, currentStack));
            stackSize -= currentStack;
        }
        addItem?.Invoke();
    }
    public void AddRandomItem()
    {
        ItemData[] allItems = Resources.LoadAll<ItemData>("Items");
        if (allItems.Length > 0)
        {
            ItemData randomItem = allItems[Random.Range(0, allItems.Length)];
            int randomStack = Random.Range(1, randomItem.MaxStack + 1);
            AddItem(randomItem, randomStack);
            Debug.Log($"Added {randomStack}x {randomItem.ItemName}");
        }
    }
    
    public void Heal(float amount)
    {
        CurrentHealth += amount;
    }
    
}
