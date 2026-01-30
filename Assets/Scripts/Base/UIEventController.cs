using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 委托事件
/// </summary>
public class UIEventController : MonoBehaviour
{
    private static UIEventController instance;
    public static UIEventController Instance => instance;

    public event Action OnClickDownE;
    public event Action OnClickDownQ;
    public event Action OnClickDownD;
    public event Action OnClickDownA;

    public Action<int> OnMoneyAdd;
    

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnClickDownE?.Invoke();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OnClickDownQ?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnClickDownD?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnClickDownA?.Invoke();
        }
        
        
    }
}
