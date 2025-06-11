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
    
    
    // 장착 가능한 아이템의 스탯 정보 가져오기
    
}

