using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 选择外出面板
/// </summary>
public class ChoosePanel : BasePanel
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
        
        character1.onClick.AddListener(() =>
        {
            if (_imageObj1.activeInHierarchy)
            {
                _imageObj1.SetActive(false);
                return;
            }
            _imageObj1.SetActive(true);
        });
        character2.onClick.AddListener(() =>
        {
            if (_imageObj2.activeInHierarchy)
            {
                _imageObj2.SetActive(false);
                return;
            }
            _imageObj2.SetActive(true);
        });
        character3.onClick.AddListener(() =>
        {
            if (_imageObj3.activeInHierarchy)
            {
                _imageObj3.SetActive(false);
                return;
            }
            _imageObj3.SetActive(true);
        });
        character4.onClick.AddListener(() =>
        {
            if (_imageObj4.activeInHierarchy)
            {
                _imageObj4.SetActive(false);
                return;
            }
            _imageObj4.SetActive(true);
        });
        
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChoosePanel>();
        });
        
        btSure.onClick.AddListener(() =>
        {
            if (_imageObj1.activeInHierarchy) _role1.GoOutSide();
            if (_imageObj2.activeInHierarchy) _role2.GoOutSide();
            if (_imageObj3.activeInHierarchy) _role3.GoOutSide();
            if (_imageObj4.activeInHierarchy) _role4.GoOutSide();
        });
    }
}
