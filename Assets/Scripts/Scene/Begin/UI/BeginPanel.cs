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
            StartCoroutine(StartGameFlow());
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
    
    private IEnumerator StartGameFlow()
    {
        
        
        ChangeDayPanel changeDayPanel = UIManager.Instance.ShowPanel<ChangeDayPanel>();
        changeDayPanel.labDay.text = "1";
        
        yield return new WaitForSeconds(4f);
        
        UIManager.Instance.ShowPanel<GamePanel>();
        UIManager.Instance.HidePanel<BeginPanel>();
        SceneManager.LoadScene("GameScene");
        BookPanel bookPanel = UIManager.Instance.ShowPanel<BookPanel>();
        bookPanel.gameObject.SetActive(false);
    }

    

}