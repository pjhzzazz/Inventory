using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class UIBase : MonoBehaviour
{
    private CanvasGroup _cg;

    private void Awake()
    {
        _cg = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close(bool kill = false) //옵셔널 파라미터
    {
        if (kill)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.SetActive(false);
    }
}
