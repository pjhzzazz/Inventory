using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region 싱글톤 구현

    

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            if (_instance == null)
            {
                _instance = new GameObject("UIManager").AddComponent<UIManager>();
                DontDestroyOnLoad(_instance);
            }
            
            return _instance;
        }
    }
    #endregion

    public MainUI MainUI;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    Dictionary<string, UIBase> _uiList = new Dictionary<string, UIBase>();

    private string GetUIName<T>() where T : UIBase
    {
        return typeof(T).Name;
    }
    public void Open<T>() where T : UIBase
    {
        string uiName = GetUIName<T>();
        if (_uiList.ContainsKey(uiName))
        {
            _uiList[uiName].Open();
        }
        else
        {
            T ui = Instantiate(Resources.Load<T>($"UI/{uiName}"));
            _uiList.Add(uiName, ui);
            ui.Open();
        }
    }
    
    public void Close<T>(bool kill = false) where T : UIBase
    {
        string uiName = GetUIName<T>();
        if (_uiList.ContainsKey(uiName))
        {
            _uiList[uiName].Close(kill);
        }

        if (kill)
        {
            _uiList.Remove(uiName);
        }
    }

    public bool TryGet<T>(out T ui) where T : UIBase
    {
        ui = null;
        
        string uiName = GetUIName<T>();
        if (_uiList.TryGetValue(uiName, out UIBase savedUI) == false)
            return false;
        
        ui = savedUI as T;
        
        return true;
    }
}
