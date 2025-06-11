using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemData itemData;
    public int stackSize;
    public bool IsEquipped { get; set; }
    
    // ItemData의 속성들에 쉽게 접근하기 위한 프로퍼티들
    public string Name => itemData.ItemName;
    public string Description => itemData.Description;
    public ItemType Type => itemData.ItemType;
    public Sprite Icon => itemData.ItemIcon;
    public int Price => itemData.Price;
    public int MaxStack => itemData.MaxStack;
    public bool CanStack => itemData.canStack;
    
    public Item(ItemData data, int stack = 1)
    {
        itemData = data;
        stackSize = stack;
        IsEquipped = false;
    }
    
    // 소모품 사용
    public void Use(Player player)
    {
        if (itemData.ItemType != ItemType.Consumable) return;
        
        foreach (var consumable in itemData.Consumables)
        {
            switch (consumable.consumableType)
            {
                case ConsumableType.Health:
                    
                    break;
                case ConsumableType.Mana:
                    
                    break;
            }
        }
        
        // 스택 감소
        stackSize--;
    }
    
    // 장착 가능한 아이템의 스탯 정보 가져오기
    public Dictionary<StatType, float> GetStat()
    {
        var stats = new Dictionary<StatType, float>();
        
        if (itemData.ItemType == ItemType.Equipable)
        {
            foreach (var equipable in itemData.Equipables)
            {
                if (stats.ContainsKey(equipable.StatType))
                    stats[equipable.StatType] += equipable.Value;
                else
                    stats[equipable.StatType] = equipable.Value;
            }
        }
        
        return stats;
    }
}

