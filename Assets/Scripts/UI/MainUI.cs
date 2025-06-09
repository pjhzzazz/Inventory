using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIBase
{
    public Button StatusBtn;
    public Button InventoryBtn;

    protected override void Awake()
    {
        base.Awake();

        StatusBtn = transform.Find("StatusBtn").GetComponent<Button>();
        InventoryBtn = transform.Find("InventoryBtn").GetComponent<Button>();

        UIManager.Instance.MainUI = this;
    }
    
    void Start()
    {
        StatusBtn.onClick.AddListener(() =>
            {
                UIManager.Instance.Open<StatusUI>();
                StatusBtn.gameObject.SetActive(false);
                InventoryBtn.gameObject.SetActive(false); 
            }
        );
        InventoryBtn.onClick.AddListener(()
            =>
        {
            UIManager.Instance.Open<InventoryUI>();
            StatusBtn.gameObject.SetActive(false);
            InventoryBtn.gameObject.SetActive(false); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
