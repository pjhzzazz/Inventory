using System.Collections;
using System.Collections.Generic;
using System.Data;
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

    private Player currentPlayer;
 

    protected override void Awake()
    {
        base.Awake();

        exitBtn = GetComponentInChildren<Button>();
    }

    private void OnEnable()
    {
        if (currentPlayer != null)
        {
            // 이벤트 재구독 (중복 방지를 위해 먼저 해제)
            currentPlayer.onStatsChanged -= UpdateStatus;
            currentPlayer.onStatsChanged += UpdateStatus;
            
            // UI 즉시 업데이트
            UpdateStatus(currentPlayer);
        }
    }
    void Start()
    {
        currentPlayer = FindObjectOfType<Player>();
        exitBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.Close<StatusUI>();
            UIManager.Instance.MainUI.StatusBtn.gameObject.SetActive(true);
            UIManager.Instance.MainUI.InventoryBtn.gameObject.SetActive(true); 
        });
    }
   
    public void SetStatus(Player player)
    {
        player.onStatsChanged += UpdateStatus;
        
        UpdateStatus(player);
    }

    private void UpdateStatus(Player player)
    {
        Attack.text = $"Attack \n {player.Attack:F1}";
        Health.text = $"Health \n {player.CurrentHealth:F0}/{player.MaxHealth:F0}";
        Defense.text = $"Defense \n {player.Defense:F1}";
        Critical.text = $"Critical \n {player.Critical:F1}";
    }

}
