using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : UIBase
{
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;
    public TextMeshProUGUI ItemType;
    public TextMeshProUGUI ItemPrice;

    public RectTransform TooltipPanel;
    private Canvas parentCanvas;
    
    protected override void Awake()
    {
        base.Awake();
        parentCanvas = GetComponent<Canvas>();
    }

    void Start()
   
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTooltip(Item item, Vector2 mousePosition)
    {
        // 아이템 정보 설정
        SetTooltip(item);
        
        // 위치 설정
        SetTooltipPosition(mousePosition);
        
        // UIManager를 통해 열기 (이미 열려있다면 내용만 업데이트됨)
        if (!gameObject.activeInHierarchy)
        {
            UIManager.Instance.Open<ItemTooltip>();
        }
    }
    private void SetTooltip(Item item)
    {
        ItemName.text = item.Name;
        ItemDescription.text = item.Description;
        ItemType.text = item.Type.ToString();
        ItemPrice.text = item.Price.ToString();
    }

    private void SetTooltipPosition(Vector2 mousePosition)
    {
        Vector2 tooltipSize = TooltipPanel.sizeDelta;
        
        // 마우스 우측 상단에 표시하기 위한 오프셋
        Vector2 offset = new Vector2(-150f, 0f);
        
        // 초기 위치 설정 (마우스 위치 + 오프셋)
        Vector3 targetPosition = new Vector3(
            mousePosition.x + offset.x,
            mousePosition.y + offset.y,
            0
        );
        
        TooltipPanel.position = targetPosition;
    }
    public void HideTooltip()
    {
        UIManager.Instance.Close<ItemTooltip>();
    }
}
