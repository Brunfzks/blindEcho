using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundProducerManager : MonoBehaviour
{

    SphereCollider collider;
    public float time_change_distance = 3f;
    public int randomDistance = 2;
    float change_distance = 0;
    public bool useInactive = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(change_distance >= time_change_distance)
        {
            collider.radius = SoundDistance.Instance.GetRandomDistance(randomDistance, useInactive);
            change_distance = 0;
        }
        else
        {
            change_distance += Time.deltaTime;
        }
    }
}
