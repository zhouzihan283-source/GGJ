using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI管理器
/// </summary>
public class UIManager
{
   private static UIManager instance = new UIManager();
   public static UIManager Instance => instance;

    public Dictionary<string,BasePanel> panelDic = new Dictionary<string,BasePanel>();

    private Transform canvasTrans;

    private UIManager() 
    {
        //得到场景中的canvas对象
        GameObject canvas = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/Canvas"));
        canvasTrans = canvas.transform;
        //过场景不移除该对象 保证这个游戏过程中 只有一个canvas对象
        GameObject.DontDestroyOnLoad(canvas);
    } 

    /// <summary>
    /// 生成唯一的面板
    /// </summary>
    public T ShowPanel<T>() where T : BasePanel
    {
        //只需保证泛型T的类型和面版预设体名字一模一样
        string panelName = typeof(T).Name;

        if(panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/"+panelName));

        //用 false，它的位置会按照你设置的锚点、pivot、localPosition 来准确摆放在界面中
        panelObj.transform.SetParent(canvasTrans, false);

        T panel = panelObj.GetComponent<T>();

        panelDic.Add(panelName, panel);

        panel.ShowMe();

        return panel;
    }
    
    /// <summary>
    /// 可以生成多个相同的面板
    /// </summary>
    public T ShowMultiplePanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/" + panelName));

        panelObj.transform.SetParent(canvasTrans, false);

        T panel = panelObj.GetComponent<T>();

        panel.ShowMe();

        return panel;
    }


    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        string panelName = typeof(T).Name;

        if(panelDic.ContainsKey(panelName))
        {
            if(isFade)
            {
                //让面版淡出完毕后再删除它
                T panel = panelDic[panelName] as T;
                panel.HideMe(() =>
                {
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }

               
        }
    }

    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;

        if(panelDic.ContainsKey(panelName))
        {
            T panel = panelDic[panelName] as T;

            return panel;
        }

        return null;

       
    }
    


}
