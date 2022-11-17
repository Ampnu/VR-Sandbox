using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartNamePanel : MonoBehaviour
{
    //public GameObject partNamePanel;
    bool canGaze;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnablePanel()
    {
        if (RocketEngineAnimation.isExpanded) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
    }

    public void DisablePanel()
    {
        //gameObject.SetActive(false);
    }
}
