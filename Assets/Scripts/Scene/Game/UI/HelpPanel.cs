using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 帮助面板
/// </summary>
public class HelpPanel : BasePanel
{
    public Button btCloseMask;

    private void Start()
    {
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<HelpPanel>();
        });
    }
}
