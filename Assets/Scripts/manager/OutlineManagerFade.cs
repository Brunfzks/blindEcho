using UnityEngine;

public class OutlineManagerFade : MonoBehaviour
{
    private Collider objectCollider;

    public float fadeInDuration = 1.0f;   // Duração do fade-in em segundos
    public float fadeOutDuration = 5.0f;  // Duração do fade-out em segundos
    private float fadeTimer = 0.0f;       // Temporizador para acompanhar o tempo de fade
    private bool fadingIn = false;        // Flag para indicar se o objeto está atualmente em fade-in
    private bool fadingOut = false;       // Flag para indicar se o objeto está atualmente em fade-out

    private void Start()
    {
        // Inicializa os componentes
        objectCollider = GetComponent<Collider>();
        fadingOut = true;
    }

    private void Update()
    {
        // Executa o fade-in
        if (fadingIn)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeInDuration);
            SetMaterialsAlpha(alpha);

            if (fadeTimer >= fadeInDuration)
            {
                fadingIn = false;
            }
        }

        // Executa o fade-out
        if (fadingOut)
        {           
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(1.0f - (fadeTimer / fadeOutDuration));
            SetMaterialsAlpha(alpha);

            if (fadeTimer >= fadeOutDuration)
            {
                fadingOut = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Inicia o fade-in se o objeto que entrou tem a tag correta
        if (other.CompareTag("OutlinerActivator"))
        {
            fadingIn = true;
            fadeTimer = 0.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Inicia o fade-out se o objeto que saiu tem a tag correta
        if (other.CompareTag("OutlinerActivator"))
        {
            fadingOut = true;
            fadeTimer = 0.0f;
        }
    }

    // Método para definir a transparência dos materiais
    private void SetMaterialsAlpha(float alpha)
    {
        Material[] materials = GetComponent<MeshRenderer>().materials;
        Debug.Log("cor q estava" + materials[0].GetColor("_OutlineColor"));       
        for (int i = 0; i < materials.Length; i++)
        {
            Color color = materials[i].GetColor("_OutlineColor");
            color.a = alpha;
            Debug.Log(color);
            Debug.Log(materials[i].GetColor(("_OutlineColor")));
            materials[i].SetColor("_OutlineColor", color);
        }
        Debug.Log("cor q esta" + materials[0].GetColor("_OutlineColor"));
        GetComponent<MeshRenderer>().materials = materials;
    }
}
