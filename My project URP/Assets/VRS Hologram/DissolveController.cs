using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectDissolver))]
public class DissolveController : MonoBehaviour
{
    ObjectDissolver dissolver;

    private void Awake()
    {
        dissolver = GetComponent<ObjectDissolver>();
    }
    private void Start()
    {
        Dissolve();
    }

    public void Dissolve()
    {
        dissolver.DissolveOUT();
    }

    public void UnDissolve()
    {
        dissolver.DissolveIN();
    }
}
