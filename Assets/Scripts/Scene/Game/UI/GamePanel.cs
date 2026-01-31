using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    [Header("第一个角色")]
    public Button btRoleOne;
    
    [Header("第二个角色")]
    public Button btRoleTwo;
    
    [Header("第三个角色")]
    public Button btRoleThree;
    
    [Header("第四个角色")]
    public Button btRoleFour;
    
    [Header("主界面四个按钮")]
    public Button btFood;
    public Button btAct;
    public Button btNote;
    public Button btHelp;
    


    private void Start()
    {
        btRoleOne.onClick.AddListener(() =>
        {
            
        });
        
        btRoleTwo.onClick.AddListener(() =>
        {
            
        });
        
        btRoleThree.onClick.AddListener(() =>
        {
            
        });
        
        btRoleFour.onClick.AddListener(() =>
        {
            
        });
        
        btFood.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<FoodPanel>();
        });
        
        btAct.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ActionPanel>();
        });
        
        btNote.onClick.AddListener(() =>
        {
            
        });
        
        btHelp.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<HelpPanel>();
        });
        
    }
}
