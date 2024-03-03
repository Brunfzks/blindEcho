using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveReciver : MonoBehaviour
{
    // Start is called before the first frame update

    public Material inactive_material;
    void Start()
    {
        GameObject[] recivers = GameObject.FindGameObjectsWithTag("OutlinerReciver");

        foreach (GameObject reciver in recivers)
        {
            Material[] materials = reciver.GetComponent<MeshRenderer>().materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = inactive_material;
            }
            reciver.GetComponent<MeshRenderer>().materials = materials;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
