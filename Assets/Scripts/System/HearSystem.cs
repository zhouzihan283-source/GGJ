using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZZH.Core;

/// <summary>
/// 偷听系统
/// </summary>
public class HearSystem : MonoBehaviour
{
    private static HearSystem instance;
    public static HearSystem Instance => instance;
    
    private HearData hearData;
    
    private List<HearData> hearDatas;

    private void Awake()
    {
        instance = this;
        hearDatas = GameDataManager.Instance.hearDatas;
    }

    public void GetHearContent()
    {
        int num = Random.Range(1,5);
        if (hearDatas.TryFind(n => n.HearResult == num, out hearData))
        {
            BookPanel bookPanel = UIManager.Instance.GetPanel<BookPanel>();
            GameDataManager.Instance.AddContent(hearData.Content);
        }
    }
}
