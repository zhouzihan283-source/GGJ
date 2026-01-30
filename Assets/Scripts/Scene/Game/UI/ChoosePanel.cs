using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选择外出面板
/// </summary>
public class ChoosePanel : BasePanel
{
    public Button btCloseMask;

    public Button btSure;


    private void Start()
    {
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
    }
}
