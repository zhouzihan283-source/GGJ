using UnityEngine;

/// <summary>
/// 每天系统
/// </summary>
public class DaySystem : MonoBehaviour
{
    private static DaySystem instance;
    public static DaySystem Instance => instance;
    

    /// <summary> 存活天数 </summary>
    public int totalDays = 13;
    /// <summary> 当前天数 </summary>
    public int currentDay = 1;
    private bool isGameEnd = false;

    private RoleObject[] allRoles;

    private void Start()
    {
        instance = this;
        allRoles = FindObjectsOfType<RoleObject>();
    }
    

    /// <summary>
    /// 进入新的一天
    /// </summary>
    public void NextDay()
    {
        if (isGameEnd)
        {
            return;
        }

        // 所有角色扣血
        foreach (var role in allRoles)
        {
            role.OnNewDay();
        }

        // 是否进入结局
        if (currentDay >= totalDays)
        {
            EnterEnding();
            return;
        }
        GameDataManager.Instance.ClearContent();
        GameDataManager.Instance.dayCount++;

        currentDay++;
        ChangeDayPanel changeDayPanel = UIManager.Instance.ShowPanel<ChangeDayPanel>();
        changeDayPanel.labDay.text = currentDay.ToString();
    }

    /// <summary>
    /// 进入结局（第十四天）
    /// </summary>
    private void EnterEnding()
    {
        isGameEnd = true;
    }
}