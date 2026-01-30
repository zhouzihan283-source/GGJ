using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选择喂食物面板
/// </summary>
public class FoodPanel : BasePanel
{
    public Button btCloseMask;

    public Button btSure;

    private void Start()
    {
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<FoodPanel>();
        });
    }
}
