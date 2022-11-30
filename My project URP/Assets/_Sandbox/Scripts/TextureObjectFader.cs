using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureObjectFader : ObjectFader
{
    public Material fadeMaterial;

    private void Start()
    {
        GetObjectMaterials();
        FadeOut();
        print(objectMaterials.Count);
    }

    public override void SetObjectFade(float fadeAmount)
    {
        for (int i = 0; i < objectMaterials.Count; i++)
        {
            objectMaterials[i].SetFloat("_Mode", 2);
            objectMaterials[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            objectMaterials[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            objectMaterials[i].SetInt("_ZWrite", 0);
            objectMaterials[i].DisableKeyword("_ALPHATEST_ON");
            objectMaterials[i].DisableKeyword("_ALPHABLEND_ON");
            objectMaterials[i].EnableKeyword("_ALPHAPREMULTIPLY_ON");
            //objectMaterials[i].renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
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

    public override void SetObjectDefault(float fadeAmount)
    {
        base.SetObjectDefault(fadeAmount);
    }
}
    
