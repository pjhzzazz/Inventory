using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player { get; private set; }

    public StatusUI StatusUI;
    public CharacterUI CharacterUI;
    private void Awake()
    {
        
    }

    void Start()
    {
         SetData();
    }
    
    void Update()
    {

    }

    public void SetData()
    {
        Player = FindObjectOfType<Player>();
        if (Player == null)
        {
            GameObject playerObj = new GameObject("Player");
            Player = playerObj.AddComponent<Player>();
        }
        
        Player.InitializePlayer("Ji Hwan", 1, 10, 10, 5, 100, 10, 10000);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (Player != null)
        {
            CharacterUI.SetPlayerInfo(Player);
            StatusUI.SetStatus(Player);
        }
    }
    
    public void UpdatePlayer()
    {
        UpdateUI();
    }
}
