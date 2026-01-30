using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选择四种选项面板
/// </summary>
public class ActionPanel : BasePanel
{
    /// <summary> 关闭按钮 </summary>
    public Button btCloseMask;
    /// <summary> 外出按钮 </summary>
    public Button btAct;
    /// <summary> 偷听按钮 </summary>
    public Button btHear;
    /// <summary> 击杀按钮 </summary>
    public Button btKill;
    /// <summary> 偷食物按钮 </summary>
    public Button btSteal;

    private void Start()
    {
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ActionPanel>();
        });
        
        btAct.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ChoosePanel>();
        });
        
        btHear.onClick.AddListener(() =>
        {
            
        });
        
        btKill.onClick.AddListener(() =>
        {
            
        });
        
        btSteal.onClick.AddListener(() =>
        {
            
        });
    }
}
