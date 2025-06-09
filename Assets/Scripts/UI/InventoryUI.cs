using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : UIBase
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
            UIManager.Instance.Close<InventoryUI>();
            UIManager.Instance.MainUI.StatusBtn.gameObject.SetActive(true);
            UIManager.Instance.MainUI.InventoryBtn.gameObject.SetActive(true); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
