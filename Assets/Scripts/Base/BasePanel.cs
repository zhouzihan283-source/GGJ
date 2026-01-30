using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 面板基类
/// </summary>
public abstract class BasePanel : MonoBehaviour
{ 
    private CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup => canvasGroup;
    private float alphaSpeed = 10;

    public bool isShow = false;

    private UnityAction hideCallBack = null;


    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        if(canvasGroup==null)
        {
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();
        }
    }
    

    public virtual void ShowMe()
    {
        canvasGroup.alpha = 0;
        isShow = true;
    }

    public virtual void HideMe(UnityAction callBack)
    {
        canvasGroup.alpha = 1;
        isShow = false;
        hideCallBack = callBack;
    }
    
    protected virtual void Update()
    {
        if (isShow && canvasGroup.alpha != 1)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if(canvasGroup.alpha>=1)
            {
                canvasGroup.alpha = 1;
            }
        }
        else if(!isShow && canvasGroup.alpha != 0)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if(canvasGroup.alpha<=0)
            {
                canvasGroup.alpha = 0;
                //如果 hideCallBack 不为 null，就调用它；否则跳过
                hideCallBack?.Invoke();
            }
        }
            
    }
}