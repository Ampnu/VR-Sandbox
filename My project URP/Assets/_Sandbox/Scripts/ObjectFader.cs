using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    protected List<Material> objectMaterials = new List<Material>();
    protected List<Renderer> renderers = new List<Renderer>();
    bool fadeIn;
    public float fadeTranisitionTime = 1;
    public IEnumerator routine;

    private void Start()
    {
        GetObjectMaterials();
        FadeIn();
    }

    protected void GetObjectMaterials()
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

    public void FadeIn()
    {
        Fade(true);
    }

    public void FadeOut()
    {
        Fade(false);
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
        if (routine != null) StopCoroutine(routine);
    }

    IEnumerator FaderRoutine()
    {
        float elaspeTime = 0f;

        if (fadeIn == false) elaspeTime = fadeTranisitionTime;
        else fadeTranisitionTime = 3 * fadeTranisitionTime;

        while (0 <= elaspeTime && elaspeTime <= fadeTranisitionTime)
        {
            if (fadeIn == true) elaspeTime += Time.deltaTime;
            else elaspeTime -= Time.deltaTime;

            float result = elaspeTime / fadeTranisitionTime;
            if (fadeIn == false) SetObjectFade(result);
            else SetObjectDefault(result);

            yield return null;
        }
    }

    public virtual void SetObjectFade(float fadeAmount)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            Color newObjectColor = objectMaterials[i].color;
            newObjectColor = new Color(newObjectColor.r, newObjectColor.g, newObjectColor.b, fadeAmount);
            renderers[i].material.color = newObjectColor;
        }
    }

    public virtual void SetObjectDefault(float fadeAmount)
    {
        for (int i = 0; i < renderers.Count; i++)
        {
            //Color newObjectColor = objectMaterials[i].color;
            //newObjectColor = new Color(newObjectColor.r, newObjectColor.g, newObjectColor.b, 0);
            //renderers[i].material.color = newObjectColor;
        }

        for (int i = 0; i < renderers.Count; i++)
        {
            //Color newObjectColor = objectMaterials[i].color;
            //newObjectColor = new Color(newObjectColor.r, newObjectColor.g, newObjectColor.b, fadeAmount);
            //renderers[i].material.color = newObjectColor;
        }
    }
}
