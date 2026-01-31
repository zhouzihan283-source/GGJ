using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ZZH.Core;
/// <summary>
/// 角色实体
/// </summary>
public class RoleObject : MonoBehaviour
{
    public RoleName roleName;
    
    public int maxHp = 3;
    public int currentHp;

    public Image imgRole;
    public Text labName;
    public Text labState;

    private RoleLifeState currentState;
    public RoleLifeState CurrentState => currentState;
    
    private RoleEffect currentEffect;
    public RoleEffect CurrentEffect => currentEffect;
    
    private List<RoleData> roleDatas;
    

    public void InitData()
    {
        roleDatas = GameDataManager.Instance.roleDatas;
        currentHp = maxHp;
        if (roleDatas.TryFind(n => n.RoleName == roleName.ToString(),out RoleData data))
        {
            labName.text = data.CnName;
        }
        
        // 鼠标进入
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener((data) =>
        {
            if (roleDatas.TryFind(n => n.RoleName == roleName.ToString() && n.State == currentState.ToString(),
                    out RoleData _data))
            {
                if (_data.HighlightSprite != null)
                {
                    Sprite roleSprite = Resources.Load<Sprite>("Sprite/Character/" + _data.HighlightSprite);
                    imgRole.sprite = roleSprite;   
                }
            }
        });

        // 鼠标移出
        EventTrigger.Entry exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener((data) =>
        {
            if (roleDatas.TryFind(n => n.RoleName == roleName.ToString() && n.State == currentState.ToString(),
                    out RoleData _data))
            {
                Sprite roleSprite = Resources.Load<Sprite>("Sprite/Character/" + _data.NormalSprite);
                imgRole.sprite = roleSprite;   
            }
        });

        trigger.triggers.Add(enter);
        trigger.triggers.Add(exit);
        
        UpdateState();
    }

    /// <summary>
    /// 外出
    /// </summary>
    public void GoOutSide()
    {
        if (currentState == RoleLifeState.death)
            return;

        currentEffect = RoleEffect.panic;
        currentHp = 1;
        DaySystem.Instance.NextDay();
    }

    /// <summary>
    /// 每天扣血
    /// </summary>
    public void OnNewDay()
    {
        if (currentState == RoleLifeState.death)
        {
            return;
        }

        if (currentEffect != RoleEffect.panic)
        {
            currentHp--;   
        }

        UpdateState();
    }

    /// <summary>
    /// 吃食物，直接回满
    /// </summary>
    public void EatFood()
    {
        if (currentState == RoleLifeState.death)
        {
            return;
        }

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
            currentState = RoleLifeState.death;
        }
        else if (currentHp == 1)
        {
            currentState = RoleLifeState.weak;
        }
        else
        {
            currentState = RoleLifeState.normal;
        }

        //如果有惊慌状态
        if (currentEffect == RoleEffect.panic)
        {
            if (roleDatas.TryFindAll(n => n.RoleName == roleName.ToString(),out List<RoleData> data))
            {
                string _string = "";
                for (int i = 0; i < data.Count; i++)
                {
                    if (data[i].State == currentState.ToString() || data[i].State == RoleEffect.panic.ToString())
                    {
                        _string += data[i].CnState + "、";
                    }
                }
                labState.text = _string;
                Sprite roleSprite = Resources.Load<Sprite>("Sprite/Character/" + data.Find(n=>n.State==RoleEffect.panic.ToString()).NormalSprite);
                imgRole.sprite = roleSprite;
            }
        }
        //如果没有惊慌状态
        else
        {
            if (roleDatas.TryFind(n => n.RoleName == roleName.ToString() && n.State == currentState.ToString(),out RoleData data))
            {
                labState.text = data.CnState;
                Sprite roleSprite = Resources.Load<Sprite>("Sprite/Character/" + data.NormalSprite);
                imgRole.sprite = roleSprite;
            }
        }

        
    }
}
