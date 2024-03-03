using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum SounddistanceE {inactive, weak, normal, strong, gigante}
public class SoundDistance : MonoBehaviour
{

    public static SoundDistance Instance { get; private set; }
    private void Awake()

    {

        if (Instance != null && Instance != this)

        {

            Destroy(this);

        }

        else

        {

            Instance = this;

        }


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetRandomDistance(int range, bool useInactive = false)
    {
        var v = SounddistanceE.GetValues(typeof(SounddistanceE));
        return  GetDistance((SounddistanceE)v.GetValue(UnityEngine.Random.Range(useInactive ? 0 : 1, range)));
    }

    public float GetDistance(SounddistanceE d)
    {
        
        switch(d)
        {
            case SounddistanceE.inactive:
                return 0.001f;                
            case SounddistanceE.weak:
                return 2f;                
            case SounddistanceE.normal:
                return 5f;
            case SounddistanceE.strong:
                return 10f;
            case SounddistanceE.gigante:
                return 50f;
            default:
                return 1f;   
        }       
    }
}
