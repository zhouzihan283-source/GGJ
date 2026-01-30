using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音乐管理器
/// </summary>
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance => instance; 

    private AudioSource audioSource;



    private void Awake()
    {
        instance = this;

        audioSource = this.GetComponent<AudioSource>();


        MusicData data = GameDataManager.Instance.musicData;
        SetIsOpen(data.ToggleMusic);
        ChangeValue(data.slideMusic);
    }

    public void SetIsOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }

    public void ChangeValue(float v)
    {
        audioSource.volume = v;
    }

    
}