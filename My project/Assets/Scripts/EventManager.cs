using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction SetInfoPanel;
    public static void OnInfoPanelSet() => SetInfoPanel?.Invoke();
}
