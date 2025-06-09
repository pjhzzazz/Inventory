using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI PlayerLevel;
    public TextMeshProUGUI PlayerExp;
    public TextMeshProUGUI PlayerGold;
    
    public void SetPlayerInfo(Player player)
    {
        if (player != null)
        {
            PlayerName.text = player.Name;
            PlayerLevel.text = player.Level.ToString("D2");
            PlayerExp.text = $"{player.CurrentExp}/{player.MaxExp}";
            PlayerGold.text = player.Gold.ToString();
        }
    }

}
