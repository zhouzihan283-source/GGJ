using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public GameObject roleObjectPrefab;
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
        GameObject objOne = Instantiate(roleObjectPrefab, btRoleOne.transform);
        GameObject objTwo = Instantiate(roleObjectPrefab, btRoleTwo.transform);
        GameObject objThree = Instantiate(roleObjectPrefab, btRoleThree.transform);
        GameObject objFour = Instantiate(roleObjectPrefab, btRoleFour.transform);
        RoleObject roleObjOne = objOne.GetComponent<RoleObject>();
        RoleObject roleObjTwo = objTwo.GetComponent<RoleObject>();
        RoleObject roleObjThree = objThree.GetComponent<RoleObject>();
        RoleObject roleObjFour = objFour.GetComponent<RoleObject>();
        roleObjOne.roleName = RoleName.role1;
        roleObjTwo.roleName = RoleName.role2;
        roleObjThree.roleName = RoleName.role3;
        roleObjFour.roleName = RoleName.role4;
        roleObjOne.InitData();
        roleObjTwo.InitData();
        roleObjThree.InitData();
        roleObjFour.InitData();
        
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
        //食物
        btFood.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<FoodPanel>();
        });
        //行动
        btAct.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ActionPanel>();
        });
        //日志
        btNote.onClick.AddListener(() =>
        {
            BookPanel bookPanel = UIManager.Instance.GetPanel<BookPanel>();
            bookPanel.gameObject.SetActive(true);
            bookPanel.SetContent();
        });
        //帮助
        btHelp.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<HelpPanel>();
        });
        
    }
}
