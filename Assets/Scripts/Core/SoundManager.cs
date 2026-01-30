using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音效管理器
/// </summary>
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;
    
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string resName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/Sound/"+resName);
        audioSource.volume = GameDataManager.Instance.musicData.slideSound;
        audioSource.mute = !GameDataManager.Instance.musicData.ToolleSound;

        //可以多个音效叠加播放
        audioSource.PlayOneShot(clip);
        
    }
}
