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
        //print(objIndex);
        if (objIndex != -1 && objIndex > 0)
        {
            //print("Seq Move");
            objIndex--;
            Move(false);

        }
        else
        {
            //print("Intiial Start " + (objList.Count - 1));
            objIndex = objList.Count - 1;
            Move(false);
        }
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
            //LerpCarouselLeft(result);
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

                if (percentage > 0.1f) { objList[objIndex].SetActive(true); }
                if (percentage > 0.9f) { objList[objIndex - 1].SetActive(false); }
            }
            else
            {
                objList[0].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
                objList[objList.Count - 1].transform.position = Vector3.Lerp(centerPoint.position, endPoint.position, lerpCurve.Evaluate(percentage));

                if (percentage > 0.1f) { objList[0].SetActive(true); }
                if (percentage > 0.9f) { objList[objList.Count - 1].SetActive(false); }
            }
                     
        }
    }

    void LerpCarouselRight(float percentage)
    {
        if (objIndex < objList.Count)
        {
            //print(objIndex);
            if (objIndex != -1 && objIndex > 0)
            {
                objList[objIndex].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
                objList[objIndex - 1].transform.position = Vector3.Lerp(centerPoint.position, endPoint.position, lerpCurve.Evaluate(percentage));

                if (percentage < 0.1f) { objList[objIndex].SetActive(false); }
                if (percentage > 0.9f) { objList[objIndex - 1].SetActive(true); }
            }
            else
            {
                //print("Start From Begining");
                objList[0].transform.position = Vector3.Lerp(startPoint.position, centerPoint.position, lerpCurve.Evaluate(percentage));
                objList[objList.Count -1].transform.position = Vector3.Lerp(centerPoint.position, endPoint.position, lerpCurve.Evaluate(percentage));

                if (percentage < 0.1f) { objList[0].SetActive(false); }
                if (percentage > 0.9f) { objList[objList.Count - 1].SetActive(true); }
               
            }
        }
    }
}
