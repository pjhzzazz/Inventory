using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : UIBase
{
    private Button exitBtn;

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
    void Update()
    {
        
    }
}
