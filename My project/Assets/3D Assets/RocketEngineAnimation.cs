using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using System;

public class RocketEngineAnimation : MonoBehaviour
{
    public Animator animator;

    public static Action AnimationSet;
    public static void OnAnimtionSet() => AnimationSet.Invoke();

    public static bool isExpanded = false;
    
    public void PlayExpand()
    {
        animator.SetBool("isExpanded", true);
        //isExpanded = true;
    }

    public void PlayCollapse()
    {
        animator.SetBool("isExpanded", false);
        //isExpanded = false;
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Expand"))
        {
            isExpanded = true;
        }
        else
        {
            isExpanded=false;
        }
    }
}
