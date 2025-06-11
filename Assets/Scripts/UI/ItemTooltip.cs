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
    private Canvas Canvas;
    
    protected override void Awake()
    {
        base.Awake();
        Canvas = GetComponent<Canvas>();
    }
    
    public void ShowTooltip(Item item, Vector2 mousePosition)
    {
        // 아이템 정보 설정
        SetTooltip(item);
        
        // 위치 설정
        SetTooltipPosition(mousePosition);
        
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
