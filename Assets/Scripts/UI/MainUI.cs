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
    }
    
    void Start()
    {
        StatusBtn.onClick.AddListener(() => UIManager.Instance.Open<StatusUI>());
        InventoryBtn.onClick.AddListener(() => UIManager.Instance.Open<InventoryUI>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
