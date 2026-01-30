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
    
    
    

    private GameDataManager()
    {
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
    }
    
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
    


}