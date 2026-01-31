using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 切换下一天动画面板
/// </summary>
public class ChangeDayPanel : BasePanel
{
    public Text labDay;
    
    public void Delete()
    {
        UIManager.Instance.HidePanel<ChangeDayPanel>();
    }
}
