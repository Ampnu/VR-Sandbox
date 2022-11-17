using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class InfoButton : MonoBehaviour
{
    public static event UnityAction SetInfoPanel;
    public static void OnInfoPanelSet() => SetInfoPanel?.Invoke();

    public void SetPanel()
    {
       //EventManager.OnInfoPanelSet();
        OnInfoPanelSet();
    }
}
