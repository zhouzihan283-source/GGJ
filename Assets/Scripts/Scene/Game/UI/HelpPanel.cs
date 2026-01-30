using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ∞Ô÷˙√Ê∞Â
/// </summary>
public class HelpPanel : BasePanel
{
    public Button btCloseMask;

    private void Start()
    {
        btCloseMask.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<HelpPanel>();
        });
    }
}
