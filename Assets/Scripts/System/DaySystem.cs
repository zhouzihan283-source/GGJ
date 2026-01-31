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
    /// <summary> 每天持续时间 </summary>
    private float dayDuration = 5f;
    private float timer;
    private bool isGameEnd = false;

    private RoleObject[] allRoles;

    private void Start()
    {
        instance = this;
        allRoles = FindObjectsOfType<RoleObject>();
        timer = dayDuration;
        Debug.Log($"第 {currentDay} 天开始");
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

        currentDay++;
        timer = dayDuration;

        Debug.Log($"第 {currentDay} 天开始");
    }

    /// <summary>
    /// 进入结局（第十四天）
    /// </summary>
    private void EnterEnding()
    {
        isGameEnd = true;
    }
}