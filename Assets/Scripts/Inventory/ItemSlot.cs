using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
     , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image Icon;
    public TextMeshProUGUI QuantityText;
    public TextMeshProUGUI EquippedText;

    public Item currentItem;
    public bool Equipped;
    public InventoryUI parentInventory;
    public void Initialize(InventoryUI inventory)
    {
        parentInventory = inventory;
    }
    private void OnEnable()
    {
        EquippedText.gameObject.SetActive(Equipped);
    }


    public void SetItem(Item Item)
    {
        currentItem = Item;
        if (currentItem != null)
        {
            Equipped = currentItem.IsEquipped;
        }
        RefreshUI();
    }

    public void ClearItem()
    {
        Icon.gameObject.SetActive(false);
        QuantityText.gameObject.SetActive(false);
        EquippedText.gameObject.SetActive(false);
        currentItem = null;
        Equipped = false;
    }

    public void RefreshUI()
    {
        if (currentItem == null)
        {
            ClearItem();
            return;
        }
        
        if (currentItem.Icon != null)
        {
            Icon.sprite = currentItem.Icon;
            Icon.gameObject.SetActive(true);
        }
        else
        {
            Icon.gameObject.SetActive(false);
        }
        if (QuantityText != null)
        {
            if (currentItem.stackSize > 1)
            {
                QuantityText.text = currentItem.stackSize.ToString();
                QuantityText.gameObject.SetActive(true);
            }
            else
            {
                QuantityText.gameObject.SetActive(false);
            }
        }
        
        Equipped = currentItem.IsEquipped;
        EquippedText.gameObject.SetActive(Equipped);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentItem != null)
        {
            // UIManager를 통해 툴팁 가져오기
            if (UIManager.Instance.TryGet(out ItemTooltip tooltip))
            {
                tooltip.ShowTooltip(currentItem, eventData.position);
            }
            else
            {
                // 툴팁이 없다면 새로 생성
                UIManager.Instance.Open<ItemTooltip>();
                if (UIManager.Instance.TryGet(out tooltip))
                {
                    tooltip.ShowTooltip(currentItem, eventData.position);
                }
            }
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        if (UIManager.Instance.TryGet(out ItemTooltip tooltip))
        {
            tooltip.HideTooltip();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 1)
        {
    
        }
        else if (eventData.clickCount == 2)
        {
            //Equip();
            //Consume();
        }
    }
 
    
}
