using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : UIBase
{
    private Button exitBtn;

    public TextMeshProUGUI Attack;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Defense;
    public TextMeshProUGUI Critical;

    public void SetStatus(Player player)
    {
        Attack.text = $"Attack \n {player.Attack:F1}";
        Health.text = $"Health \n {player.CurrentHealth:F0}/{player.MaxHealth:F0}";
        Defense.text = $"Defense \n {player.Defense:F1}";
        Critical.text = $"Critical \n {player.Critical:F1}";
    }
    
    protected override void Awake()
    {
        base.Awake();

        exitBtn = GetComponentInChildren<Button>();
    }

    void Start()
    {
        exitBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.Close<StatusUI>();
            UIManager.Instance.MainUI.StatusBtn.gameObject.SetActive(true);
            UIManager.Instance.MainUI.InventoryBtn.gameObject.SetActive(true); 
        });
    }

}
