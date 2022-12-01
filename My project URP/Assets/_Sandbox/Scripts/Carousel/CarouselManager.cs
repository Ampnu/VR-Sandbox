using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselManager : MonoBehaviour
{
    public Transform startPoint;
    public Transform centerPoint;
    public Transform endPoint;
    //[Range(0,1)] public float percentage;
    bool lerpLeft;
    public float duration;
    public IEnumerator routine;
    public AnimationCurve lerpCurve;

    public List<GameObject> objList;
    int indexCounter = 0;
    int objIndex = -1;

    //private void Start()
    //{
    //    MoveObjectLeft();
    //}

    public void MoveObjectLeft()
    {
        if(objIndex < objList.Count-1)
        {
            objIndex++;
            Move(true);
        }
        else
        {
            
            Move(true);
            objIndex = 0;
        }
        
    }
    
    public void MoveObjectRight()
    {
        Move(false);
        objIndex--;
    }  

    void Move(bool moveDir)
    {
        if (objList.Count == 0) { Debug.LogError("No Objects in List for " + this); return; }

        lerpLeft = moveDir;
        StopMovement();
        routine = MoveRoutine();
        StartCoroutine(routine);
    }

    void StopMovement()
    {
        if(routine != null) StopCoroutine(routine);
    }

    IEnumerator MoveRoutine()
    {
        float elaspeTime = 0f;

        if (lerpLeft == false) elaspeTime = duration;

        while (0 <= elaspeTime && elaspeTime <= duration)
        {
            if (lerpLeft == true) elaspeTime += Time.deltaTime;
            else elaspeTime -= Time.deltaTime;

            float result = elaspeTime / duration;
            if(lerpLeft) { LerpCarouselLeft(result); }
            else { LerpCarouselRight(result); }
            
            yield return null;
        }
    }

    void LerpCarouselLeft(float percentage)
    {
        if (objIndex < objList.Count)
        {                    
            if (objIndex > 0)
            {
                objList[objIndex].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
                objList[objIndex - 1].transform.position = Vector3.Lerp(centerPoint.position, endPoint.position, lerpCurve.Evaluate(percentage));
            }
            else
            {
                objList[objIndex].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
            }         
        }
    }

    void LerpCarouselRight(float percentage)
    {
        if (objIndex < objList.Count)
        {
            if (objIndex > 0)
            {
                print("Move Boi");
                objList[objIndex].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
                objList[objIndex - 1].transform.position = Vector3.Lerp(centerPoint.position, endPoint.position, lerpCurve.Evaluate(percentage));
            }
            else
            {
                objList[objIndex].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
            }
        }
    }
}
