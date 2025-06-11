using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemData itemData;
    public int stackSize;
    public bool IsEquipped { get; set; }
    
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
                    player.Heal(consumable.value);
                    break;
                case ConsumableType.Mana:
                    
                    break;
            }
        }

        stackSize--;
    }
    
    // 장착 가능한 아이템의 스탯 정보 가져오기
    
}

