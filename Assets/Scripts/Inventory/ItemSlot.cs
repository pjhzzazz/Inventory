using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
    // , IPointerEnterHandler, IPointerExitHandler,
    // IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Image Icon;
    public TextMeshProUGUI QuantityText;
    public TextMeshProUGUI EquippedText;

    public Item currentItem;
    private Player player;
    public bool Equipped;
    public int Quantity;
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
        RefreshUI();
    }

    public void ClearItem( )
    {
        Icon.gameObject.SetActive(false);
        QuantityText.gameObject.SetActive(false);
        EquippedText.gameObject.SetActive(false);
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
    }
    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     
    // }
    //
    // public void OnPointerExit(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }
    //
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     if (eventData.clickCount == 1)
    //     {
    //
    //     }
    //     else if (eventData.clickCount == 2)
    //     {
    //         //Equip();
    //         //Consume();
    //     }
    // }
    //
    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }
    //
    // public void OnDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }
    //
    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }

}
