using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class RocketEngineAnimation : MonoBehaviour
{
    public Animator animationController;
    
    public void PlayExpand()
    {
        animationController.SetBool("isExpanded", true);
    }

    public void PlayCollapse()
    {
        animationController.SetBool("isExpanded", false);
    }
}
