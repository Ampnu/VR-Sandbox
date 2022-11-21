using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public GameObject infoPanel;

    bool panelEnable;
    
    private void Awake()
    {
        InfoButton.SetInfoPanel += SetPanel;
        infoPanel.SetActive(false);
    }


    //void Foo()
    //{
    //    print("GO");
    //}

    void Start()
    {
        infoPanel.SetActive(false);
    }

    void SetPanel()
    {
        if (!panelEnable)
        {
            EnablePanel();
            panelEnable = true;
        }
        else
        {
            DisablePanel();
            panelEnable = false;
        }
    }

    public void EnablePanel()
    {
        infoPanel.SetActive(true);
    }

    public void DisablePanel()
    {
        infoPanel.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.SetInfoPanel -= SetPanel;
    }
}
