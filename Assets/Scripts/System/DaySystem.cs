using UnityEngine;

/// <summary>
/// 每天系统
/// </summary>
public class DaySystem : MonoBehaviour
{

    /// <summary> 存活天数 </summary>
    public int totalDays = 13;
    /// <summary> 当前天数 </summary>
    public int currentDay = 1;
    /// <summary> 每天持续时间 </summary>
    public float dayDuration = 10f;
    private float timer;
    private bool isGameEnd = false;

    private RoleObject[] allRoles;

    private void Start()
    {
        allRoles = FindObjectsOfType<RoleObject>();
        timer = dayDuration;
        
    }

    private void Update()
    {
        if (isGameEnd)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            NextDay();
        }
    }

    /// <summary>
    /// 进入新的一天
    /// </summary>
    private void NextDay()
    {

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