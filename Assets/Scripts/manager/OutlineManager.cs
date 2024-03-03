using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    private Collider objectCollider;

    public Material activeShader;
    public Material inactiveShader;


    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    private void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OutlinerReciver"))
        {
            other.GetComponent<OutlineFadeManager>().FadeOut();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OutlinerReciver"))
        {
            Debug.Log("teste");
            other.GetComponent<OutlineFadeManager>().StopFadeOut();
            SetMaterials(activeShader, other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OutlinerReciver"))
        {
            other.GetComponent<OutlineFadeManager>().StopFadeOut();
            SetMaterials(activeShader, other.gameObject);
        }
    }

    private void SetMaterials(Material material, GameObject collider)
    {
        Material[] materials = collider.GetComponent<MeshRenderer>().materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = material;
        }
        collider.GetComponent<MeshRenderer>().materials = materials;
    }
}
