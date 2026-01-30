using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 设置界面
/// </summary>
public class SettingPanel : BasePanel
{
    public Button btClose;
    public Toggle togleMusic;
    public Toggle togleSound;
    public Slider sliderMusic;
    public Slider sliderSound;

    public void Start()
    {
        MusicData data = GameDataManager.Instance.musicData;

        togleMusic.isOn = data.ToggleMusic;
        togleSound.isOn = data.ToolleSound;
        sliderMusic.value = data.slideMusic;
        sliderSound.value = data.slideSound;


        btClose.onClick.AddListener(() =>
        {
            GameDataManager.Instance.SaveMusicData();
            UIManager.Instance.HidePanel<SettingPanel>();            
        });

        togleMusic.onValueChanged.AddListener((v) =>
        {
            MusicManager.Instance.SetIsOpen(v);
            //记录开关的数据
            GameDataManager.Instance.musicData.ToggleMusic = v;
            
        });

        togleSound.onValueChanged.AddListener((v) =>
        {
            GameDataManager.Instance.musicData.ToolleSound = v;
        });

        sliderMusic.onValueChanged.AddListener((v) =>
        {
            MusicManager.Instance.ChangeValue(v);
            //记录音量数据
            GameDataManager.Instance.musicData.slideMusic = v;
        });

        sliderSound.onValueChanged.AddListener((v) =>
        {
            GameDataManager.Instance.musicData.slideSound = v;
        });
    }

    
}