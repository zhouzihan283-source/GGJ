using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    [Header("第一个角色")]
    public Button btRoleOne;
    public Image imgNormalOne;
    public Image imgNormalHightLightOne;
    public Image imgWeakOne;
    public Image imgWeakHightLightOne;
    public Image imgPanicOne;
    public Image imgPanicHightLightOne;
    public Image imgDeathOne;
    
    [Header("第二个角色")]
    public Button btRoleTwo;
    public Image imgNormalTwo;
    public Image imgNormalHightLightTwo;
    public Image imgWeakTwo;
    public Image imgWeakHightLightTwo;
    public Image imgPanicTwo;
    public Image imgPanicHightLightTwo;
    public Image imgDeathTwo;

    
    
    [Header("第三个角色")]
    public Button btRoleThree;
    public Image imgNormalThree;
    public Image imgNormalHightLightThree;
    public Image imgWeakThree;
    public Image imgWeakHightLightThree;
    public Image imgPanicThree;
    public Image imgPanicHightLightThree;
    public Image imgDeathThree;

    
    
    [Header("第四个角色")]
    public Button btRoleFour;
    public Image imgNormalFour;
    public Image imgNormalHightLightFour;
    public Image imgWeakFour;
    public Image imgWeakHightLightFour;
    public Image imgPanicFour;
    public Image imgPanicHightLightFour;
    public Image imgDeathFour;

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
