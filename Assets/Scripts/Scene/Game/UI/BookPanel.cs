using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ZZH.Core;

/// <summary>
/// 日志面板
/// </summary>
public class BookPanel : BasePanel
{
    public Button btCloseMask;
    
    public Text scContent;
    /// <summary> 上一页 </summary>
    public Button btPrevious;
    /// <summary> 下一页 </summary>
    public Button btNext;

    public Image imgSlectPre;
    public Image imgSlectNext;
    /// <summary> 页数 </summary>
    public Text labPage;
    

    private void Start()
    {
        RefreshPageButtons();
        btPrevious.onClick.AddListener(() =>
        {
            if (GameDataManager.Instance.nowPageCount == 1)
            {
                return;
            }
            GameDataManager.Instance.nowPageCount--;
            SetContent();
            RefreshPageButtons();
        });
        
        btNext.onClick.AddListener(() =>
        {
            if (GameDataManager.Instance.nowPageCount == 14)
            {
                return;
            }
            GameDataManager.Instance.nowPageCount++;
            SetContent();
            RefreshPageButtons();
        });
        
        
        BookPanel bookPanel = UIManager.Instance.GetPanel<BookPanel>();
        
        // 鼠标进入
        EventTrigger triggerPre = btPrevious.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry enterPre = new EventTrigger.Entry();
        enterPre.eventID = EventTriggerType.PointerEnter;
        enterPre.callback.AddListener((data) =>
        {
            imgSlectPre.gameObject.SetActive(true);
        });

        // 鼠标移出
        EventTrigger.Entry exitPre = new EventTrigger.Entry();
        exitPre.eventID = EventTriggerType.PointerExit;
        exitPre.callback.AddListener((data) =>
        {
            imgSlectPre.gameObject.SetActive(false);
        });

        triggerPre.triggers.Add(enterPre);
        triggerPre.triggers.Add(exitPre);
        
        // 鼠标进入
        EventTrigger triggerNext = btNext.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry enterNext = new EventTrigger.Entry();
        enterNext.eventID = EventTriggerType.PointerEnter;
        enterNext.callback.AddListener((data) =>
        {
            imgSlectNext.gameObject.SetActive(true);
        });

        // 鼠标移出
        EventTrigger.Entry exitNext = new EventTrigger.Entry();
        exitNext.eventID = EventTriggerType.PointerExit;
        exitNext.callback.AddListener((data) =>
        {
            imgSlectNext.gameObject.SetActive(false);
        });

        triggerNext.triggers.Add(enterNext);
        triggerNext.triggers.Add(exitNext);
        
        btCloseMask.onClick.AddListener(() =>
        {
            bookPanel.gameObject.SetActive(false);
        });   
    }
    
    private void RefreshPageButtons()
    {
        int page = GameDataManager.Instance.nowPageCount;
        labPage.text = "第" + page + "页";
        btPrevious.gameObject.SetActive(page > 1);
        btNext.gameObject.SetActive(page < 14);
    }
    


    public void SetContent()
    {
        if (GameDataManager.Instance.bookDictionay.TryGetValue(GameDataManager.Instance.nowPageCount,
                out string content))
        {
            scContent.text = content;
        }
        else
        {
            scContent.text = null;
        }
    }
    
}
