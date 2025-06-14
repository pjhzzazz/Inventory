using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player { get; private set; }

    public StatusUI StatusUI;
    public CharacterUI CharacterUI;
    public InventoryUI InventoryUI;


    void Start()
    {
         SetData();
    }

    public void SetData()
    {
        Player = FindObjectOfType<Player>();
        if (Player == null)
        {
            GameObject playerObj = new GameObject("Player");
            Player = playerObj.AddComponent<Player>();
        }
        
        Player.InitializePlayer("Ji Hwan", 1, 10, 10, 5, 100, 10, 10000, 100);
        
        
        ItemData[] itemDatas = Resources.LoadAll<ItemData>("Items");
        if (itemDatas.Length == 0)
        {
            Debug.LogWarning("No items");
        }
        else
        {
            foreach(var itemData in itemDatas)
            {
                if (itemData != null)
                {
                    Debug.Log($"Add item: {itemData.ItemName}");
                    Player.AddItem(itemData, 1);
                }
            }
        }
        
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (Player != null)
        {
            CharacterUI.SetPlayerInfo(Player);
            StatusUI.SetStatus(Player); 
            InventoryUI.SetPlayerInfo(Player);
        }
    }
    
    public void UpdatePlayer()
    {
        UpdateUI();
    }
}
