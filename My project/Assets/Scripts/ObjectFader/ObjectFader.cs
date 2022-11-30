using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    List<Material> objectMaterials = new List<Material>();
    List<Renderer> renderers = new List<Renderer>();
    bool fadeIn;
    public float fadeTranisitionTime = 1;
    public IEnumerator routine;
    public Material fadeMaterial;
    Material defaultMaterial;
    
    
    private void Start()
    {
        GetObjectMaterials();
        FadeOut();
    }

    private void GetObjectMaterials()
    {
        if (renderers.Count == 0)
        {
            renderers.AddRange(gameObject.GetComponentsInChildren<Renderer>());
        }

        for (int i = 0; i < renderers.Count; i++)
        {
            objectMaterials.AddRange(renderers[i].materials);
        }
    }

    //Renderer GetFadeMaterail()
    //{
    //    Renderer renderMat = GetComponent<Renderer>();
    //    renderMat.sharedMaterial = fadeMaterial;
    //    return renderMat;
    //}

    //Renderer GetDefaultMaterial()
    //{
    //    Renderer renderMat = GetComponent<Renderer>();
    //    renderMat.sharedMaterial = defaultMaterial;
    //    return renderMat ;
    //}

    [ContextMenu("Fade In")]
    public void FadeIn()
    {
        Fade(true);
    }

    [ContextMenu("Fade Out")]
    public void FadeOut()
    {
        Fade(false);
        //Foo();
        //iTween.FadeTo(gameObject, 0, 1);
    }

    void Fade(bool fadeDirecton)
    {
        fadeIn = fadeDirecton;
        Stop();
        routine = FaderRoutine();
        StartCoroutine(routine);
    }

    void Stop()
    {
        if(routine != null) StopCoroutine(routine);
    }

    IEnumerator FaderRoutine()
    {
        float elaspeTime = 0f;

        if (fadeIn == false) elaspeTime = fadeTranisitionTime;

        while(0 <= elaspeTime && elaspeTime <= fadeTranisitionTime)
        {
            if(fadeIn == true) elaspeTime += Time.deltaTime;
            else elaspeTime -= Time.deltaTime;

            float result = elaspeTime / fadeTranisitionTime;

            SetObjectFade(result);
            //if (fadeIn) SetObjectDefault(result);
            //else SetObjectFade(result);

            yield return null; 
        }
    }

    void SetObjectFade(float fadeAmount)
    {
        //Color newObjectColor = GetFadeMaterail().material.color;
        //newObjectColor = new Color(newObjectColor.r, newObjectColor.g, newObjectColor.b, fadeAmount);

        //GetComponent<Renderer>().material.color = newObjectColor;

        for (int i = 0; i < objectMaterials.Count; i++)
        {
            objectMaterials[i].SetFloat("_Mode", 2);
            objectMaterials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objectMaterials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objectMaterials[i].SetInt("_ZWrite", 0);
            objectMaterials[i].DisableKeyword("_ALPHATEST_ON");
            objectMaterials[i].DisableKeyword("_ALPHABLEND_ON");
            objectMaterials[i].EnableKeyword("_ALPHAPREMULTIPLY_ON");
            objectMaterials[i].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }

        if (objectMaterials[0].HasProperty("_Color"))
        {
            for (int i = 0; i < objectMaterials.Count; i++)
            {
                if (objectMaterials[i].HasProperty("_Color"))
                {
                    objectMaterials[i].color = new Color(objectMaterials[i].color.r, objectMaterials[i].color.g, objectMaterials[i].color.b, fadeAmount);
                }
            }
        }
    }

    void SetObjectDefault(float fadeAmount)
    {
        //Color newObjectColor = GetFadeMaterail().material.color; ;
        //newObjectColor = new Color(newObjectColor.r, newObjectColor.g, newObjectColor.b, fadeAmount);

        //if (fadeAmount > 0.75f)
        //{
        //    //Renderer renderMat = GetComponent<Renderer>();
        //    GetComponent<Renderer>().material = defaultMaterial;
        //    GetComponent<Renderer>().material.color = Color.white;
        //}

        //GetComponent<Renderer>().material.color = newObjectColor;
    }

    void Foo()
    {
        for (int i = 0; i < objectMaterials.Count; i++)
        {
            //objectMaterials[i].SetOverrideTag("RenderType", "Fade");
            objectMaterials[i].SetFloat("_Mode", 2);
            objectMaterials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objectMaterials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objectMaterials[i].SetInt("_ZWrite", 0);
            objectMaterials[i].DisableKeyword("_ALPHATEST_ON");
            objectMaterials[i].DisableKeyword("_ALPHABLEND_ON");
            objectMaterials[i].EnableKeyword("_ALPHAPREMULTIPLY_ON");
            objectMaterials[i].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        }
    }
}
