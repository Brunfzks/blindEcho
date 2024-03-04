using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject ScannerPrefab;
    public float duration = 10;
    public float size = 500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SpawnScanner();
        }
    }

    void SpawnScanner()
    {
        GameObject scanner = Instantiate(ScannerPrefab, gameObject.transform.position, Quaternion.identity);

        ParticleSystem scannerPS = scanner.transform.GetChild(0).GetComponent<ParticleSystem>();

        if(scannerPS != null )
        {
            var main = scannerPS.main;
            main.startLifetime = duration;
            main.startSize = size;
        }

        Destroy(scanner, duration + 1);
    }
}
