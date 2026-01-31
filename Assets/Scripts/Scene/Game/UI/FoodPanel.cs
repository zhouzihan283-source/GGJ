using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZZH.Core;

/// <summary>
/// 选择喂食物面板
/// </summary>
public class FoodPanel : BasePanel
{
    public Button btCloseMask;
    public Button btSure;

    public Button character1;
    public Button character2;
    public Button character3;
    public Button character4;

    private GameObject _imageObj1;
    private GameObject _imageObj2;
    private GameObject _imageObj3;
    private GameObject _imageObj4;
    
    private RoleObject _role1;
    private RoleObject _role2;
    private RoleObject _role3;
    private RoleObject _role4;
    
    private DiaryManager _diary;

    private Options _options;

    private List<EatData> eatDatas;
    
    private void Start()
    {
        _role1 = GameObject.Find("character1Btn").GetComponentInChildren<RoleObject>();
        _role2 = GameObject.Find("character2Btn").GetComponentInChildren<RoleObject>();
        _role3 = GameObject.Find("character3Btn").GetComponentInChildren<RoleObject>();
        _role4 = GameObject.Find("character4Btn").GetComponentInChildren<RoleObject>();

        _imageObj1 = GameObject.Find("character1").transform.GetChild(0).gameObject;
        _imageObj2 = GameObject.Find("character2").transform.GetChild(0).gameObject;
        _imageObj3 = GameObject.Find("character3").transform.GetChild(0).gameObject;
        _imageObj4 = GameObject.Find("character4").transform.GetChild(0).gameObject;
        
        _options = Options.None;

        // Flags 位掩码枚举使用 |= 或等于 运算符将右边的枚举值添加到已有的枚举中，使用 A &= ~B 运算将右边的枚举值从左边的枚举中移除
        character1.onClick.AddListener(() =>
        {
            if ((_options & Options.Character1) == Options.Character1)
            {
                _imageObj1.SetActive(false);
                _options &= ~Options.Character1;
                return;
            }
            _imageObj1.SetActive(true);
            _options |= Options.Character1;
        });
        character2.onClick.AddListener(() =>
        {
            if ((_options & Options.Character2) == Options.Character2)
            {
                _imageObj2.SetActive(false);
                _options &= ~Options.Character2;
                return;
            }
            _imageObj2.SetActive(true);
            _options |= Options.Character2;
        });
        character3.onClick.AddListener(() =>
        {
            if ((_options & Options.Character3) == Options.Character3)
            {
                _imageObj3.SetActive(false);
                _options &= ~Options.Character3;
                return;
            }
            _imageObj3.SetActive(true);
            _options |= Options.Character3;
        });
        character4.onClick.AddListener(() =>
        {
            if ((_options & Options.Character4) == Options.Character4)
            {
                _imageObj4.SetActive(false);
                _options &= ~Options.Character4;
                return;
            }
            _imageObj4.SetActive(true);
            _options |= Options.Character4;
        });
        
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<FoodPanel>();
        });
        
        // Flags 位掩码枚举使用 (A & B) == B 验证枚举值 A 中是否包含枚举值 B
        btSure.onClick.AddListener(() =>
        {
            if ((_options & Options.Character1) == Options.Character1) _role1.EatFood();
            if ((_options & Options.Character2) == Options.Character2) _role2.EatFood();
            if ((_options & Options.Character3) == Options.Character3) _role3.EatFood();
            if ((_options & Options.Character4) == Options.Character4) _role4.EatFood();

            eatDatas = GameDataManager.Instance.eatDatas;

            GameDataManager.Instance.eatCount += 1;
            
            if(eatDatas.TryFind(n=>n.EatNum == GameDataManager.Instance.eatCount, out var data))
            {
                GameDataManager.Instance.AddContent(data.Content);
            }
            
            UIManager.Instance.HidePanel<FoodPanel>();
        });
    }

    [Flags]
    public enum Options
    {
        None = 0,
        Character1 = 1 << 0,
        Character2 = 1 << 1,
        Character3 = 1 << 2,
        Character4 = 1 << 3
    }
}
