using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : UIBase
{
    
    private Button exitBtn;
    public ItemSlot ItemSlotPrefab;
    public Transform ItemSlotParent;
    
    public int maxSlotCount = 24;
    
    private List<ItemSlot> itemSlots = new List<ItemSlot>();

    private Player Player;
    
    protected override void Awake()
    {
        base.Awake();

        exitBtn = GetComponentInChildren<Button>();
        Player = FindObjectOfType<Player>();

    }
    private void OnEnable()
    {
        if (itemSlots.Count > 0) // 슬롯이 이미 생성된 경우에만
        {
            RefreshInventoryUI();
        }
    }
    void Start()
    {
        Player.addItem += InitInventoryUI;
        Player.addItem += RefreshInventoryUI;
        exitBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.Close<InventoryUI>();
            UIManager.Instance.MainUI.StatusBtn.gameObject.SetActive(true);
            UIManager.Instance.MainUI.InventoryBtn.gameObject.SetActive(true); 
        });
        InitInventoryUI();
        RefreshInventoryUI();
    }
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        RefreshInventoryUI();
    }
    private void InitInventoryUI()
    {
        //기존 슬롯들 제거
        foreach (Transform child in ItemSlotParent)
        {
            Destroy(child.gameObject);
        }
        itemSlots.Clear();
        
        for (int i = 0; i < Player.Inventory.Count; i++)
        {
            if (i < maxSlotCount)
            {
                ItemSlot newSlot = Instantiate(ItemSlotPrefab, ItemSlotParent);
                newSlot.Initialize(this);
                itemSlots.Add(newSlot);
            }
        }
    }
    
    private void RefreshInventoryUI()
    {
        if (Player == null) 
        {
            Debug.Log("Player is null!");
            return;
        }

        if (Player.Inventory == null)
        {
            Debug.Log("Player inventory is null!");
            return;
        }

        Debug.Log($"Player has {Player.Inventory.Count} items in inventory");

        // 모든 슬롯 초기화
        foreach (var slot in itemSlots)
        {
            slot.SetItem(null);
        }

        // 아이템들을 슬롯에 배치
        var items = Player.Inventory;
        for (int i = 0; i < items.Count && i < itemSlots.Count; i++)
        {
            itemSlots[i].SetItem(items[i]);
        }
    }
}
