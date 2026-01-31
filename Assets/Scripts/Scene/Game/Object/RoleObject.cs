using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 角色实体
/// </summary>
public class RoleObject : MonoBehaviour
{
    public int maxHp = 3;
    public int currentHp;

    public Image imgRole;
    public Text labName;
    public Text labState;

    public RoleState CurrentState { get; private set; }

    private void Awake()
    {
        currentHp = maxHp;
        UpdateState();
    }

    /// <summary>
    /// 每天扣血
    /// </summary>
    public void OnNewDay()
    {
        if (CurrentState == RoleState.death)
        {
            return;
        }

        currentHp--;

        UpdateState();
    }

    /// <summary>
    /// 吃食物，直接回满
    /// </summary>
    public void EatFood()
    {
        if (CurrentState == RoleState.death) return;

        currentHp = maxHp;
        UpdateState();
    }

    /// <summary>
    /// 根据血量更新状态
    /// </summary>
    private void UpdateState()
    {
        if (currentHp <= 0)
        {
            CurrentState = RoleState.death;
        }
        else if (currentHp == 1)
        {
            CurrentState = RoleState.weak;
        }
        else
        {
            CurrentState = RoleState.normal;
        }

    }
}
