using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineFadeManager : MonoBehaviour
{

    Material[] objcRenderer;
    float fadeOutDuration = 2f;
    float fadeTimer;

    bool fadingOut = false;

    // Start is called before the first frame update
    void Start()
    {
       objcRenderer = GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(1.0f - (fadeTimer / fadeOutDuration));
            SetMaterialsOutlineWidth(alpha * 0.15f);  // Multiplica por 0.002 para ajustar conforme o valor máximo desejado

            if (fadeTimer >= fadeOutDuration)
            {
                fadingOut = false;
            }
        }
    }

    private void SetMaterialsOutlineWidth(float width)
    {
        Material[] materials = GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetFloat("_OutlineWidth", width);
        }
    }

    public void FadeOut()
    {
        fadingOut = true;
        fadeTimer = 0.0f;
    }

    public void StopFadeOut()
    {
        fadingOut = false;
        SetMaterialsOutlineWidth(0.15f);
        
    }
}
