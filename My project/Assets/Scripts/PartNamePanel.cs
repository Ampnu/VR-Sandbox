using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartNamePanel : MonoBehaviour
{
    public GameObject partNamePanel;


    private void Start()
    {
        partNamePanel.SetActive(false);
    }

    public void EnablePanel()
    {
        partNamePanel.SetActive(true);
    }

    public void DisablePanel()
    {
        partNamePanel.SetActive(false);
    }
}
