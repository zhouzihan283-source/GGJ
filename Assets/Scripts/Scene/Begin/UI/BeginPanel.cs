using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 开始面板
/// </summary>
public class BeginPanel : BasePanel
{
    public Button btStart;
    public Button btSetting;
    public Button btAbout;
    public Button btQuit;


    public void Start()
    {
        btStart.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<BeginPanel>();
            SceneManager.LoadScene("GameScene");
            UIManager.Instance.ShowPanel<GamePanel>();
        });

        btSetting.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<SettingPanel>();
        });

        btAbout.onClick.AddListener(() =>
        {

        });

        btQuit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    

}