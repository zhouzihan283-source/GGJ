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
    
    
    

    private GameDataManager()
    {
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        roleDatas = JsonMgr.Instance.LoadData<List<RoleData>>("RoleData");
    }
    
    public void SaveMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
    


}