using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDissolver : MonoBehaviour
{
    [Tooltip("Time it takes for objects to dissolve away")]
    [SerializeField] float dissolveTransitionTime = 1;

    List<Material> dissolveMaterials = new List<Material>();
    List<Renderer> renderers = new List<Renderer>();
    bool isDissolved;
    public IEnumerator routine;

    private void Start()
    {
        GetDissolveMaterials();
    }

    void GetDissolveMaterials()
    {
        if (renderers.Count == 0)
        {
            renderers.AddRange(gameObject.GetComponentsInChildren<Renderer>());
        }

        for (int i = 0; i < renderers.Count; i++)
        {
            if(renderers[i].material.shader.name.Equals("Shader Graphs/Fresnal Glow Dissolve"))
            {
                dissolveMaterials.AddRange(renderers[i].materials);
            }        
        }
    }

    public void DissolveIN()
    {
        Dissolve(true);
    }

    public void DissolveOUT()
    {
        Dissolve(false);
    }


    #region Helper Methods

    void Dissolve(bool fadeDirecton)
    {
        isDissolved = fadeDirecton;
        Stop();
        routine = DissolveRoutine();
        StartCoroutine(routine);
    }

    void Stop()
    {
        if (routine != null) StopCoroutine(routine);
    }

    IEnumerator DissolveRoutine()
    {
        float elaspeTime = 0f;

        if (isDissolved == false) elaspeTime = dissolveTransitionTime;
        else dissolveTransitionTime = 3 * dissolveTransitionTime;

        while (0 <= elaspeTime && elaspeTime <= dissolveTransitionTime)
        {
            if (isDissolved == true) elaspeTime += Time.deltaTime;
            else elaspeTime -= Time.deltaTime;

            float result = elaspeTime / dissolveTransitionTime;
            SetDissolveVFX(result);
            yield return null;
        }
    }

    void SetDissolveVFX(float fadeAmount)
    {
        for (int i = 0; i < renderers.Count; i++)
        {          
            renderers[i].material.SetFloat("_Dissolve_Amount",fadeAmount);
        }
    }
    #endregion
}
