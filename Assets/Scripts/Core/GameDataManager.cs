using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 数据管理器
/// </summary>
public class GameDataManager
{
    private static GameDataManager instance = new GameDataManager();

    public static GameDataManager Instance => instance;

    public MusicData musicData;
    
    public List<RoleData>  roleDatas;
    
    public List<DayData> dayDatas;
    public List<EatData> eatDatas;
    public List<EndData> endDatas;
    public List<HearData> hearDatas;
    public List<OutsideData> outsideDatas;
    
    
    

    private GameDataManager()
    {
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        roleDatas = JsonMgr.Instance.LoadData<List<RoleData>>("RoleData");
        dayDatas = JsonMgr.Instance.LoadData<List<DayData>>("DayData");
        eatDatas =  JsonMgr.Instance.LoadData<List<EatData>>("EatData");
        endDatas = JsonMgr.Instance.LoadData<List<EndData>>("EndData");
        hearDatas = JsonMgr.Instance.LoadData<List<HearData>>("HearData");
        outsideDatas = JsonMgr.Instance.LoadData<List<OutsideData>>("OutsideData");
    }
    
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
    
}