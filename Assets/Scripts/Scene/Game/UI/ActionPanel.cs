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
        //关闭遮罩
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ActionPanel>();
        });
        //外出
        btAct.onClick.AddListener(() =>
        { 
            UIManager.Instance.ShowPanel<ChoosePanel>();
        });
        //偷听
        btHear.onClick.AddListener(() =>
        {
            
        });
        //杀人
        btKill.onClick.AddListener(() =>
        {
            
        });
        //偷食物
        btSteal.onClick.AddListener(() =>
        {
            
        });
    }
}
