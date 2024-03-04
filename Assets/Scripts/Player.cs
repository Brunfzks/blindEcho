using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject outline_activer;
    public float time_disable_collider = 0.5f;
    float time_colider = 0;
    bool disable_colider = false;

    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public AudioClip wistle;
    public float stepInterval = 0.005f;
    private float stepTimer;
    void Start()
    {
        stepTimer = stepInterval;

    }

    // Update is called once per frame
    void Update()
    {
        outline_activer.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            PlayWistle();
            colliderActive(SoundDistance.Instance.GetDistance(SounddistanceE.strong));
            return;
        }

        if (disable_colider && time_colider >= time_disable_collider)
        {
            disable_colider = false;
            time_colider = 0;
            colliderInative();
            return;
        }

        if (disable_colider)
        {
            time_colider += Time.deltaTime;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moving = new Vector3(horizontal, 0f, vertical);
        moving.Normalize();

        if (moving.magnitude > 0)
        {
            colliderActive(SoundDistance.Instance.GetDistance(SounddistanceE.normal));

            stepTimer -= Time.deltaTime;
            Debug.Log(stepTimer);
            if (stepTimer <= 0)
            {
                PlayFootstepSound();
                stepTimer = stepInterval;
            }            
            return;
        }
        
        stepTimer = stepInterval;
    }

    void colliderActive(float distancia)
    {
        // outline_activer.GetComponent<Collider>().enabled = true;
        outline_activer.GetComponent<SphereCollider>().radius = distancia;
        disable_colider = true;
    }
    void colliderInative()
    {
        outline_activer.GetComponent<SphereCollider>().radius = 0.01f;
        // outline_activer.GetComponent<Collider>().enabled = false;
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length == 0 || audioSource == null)
            return;

        // Escolhe um som de passo aleatório da matriz de sons de passo
        AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];

        // Reproduz o som de passo
        audioSource.PlayOneShot(footstepSound);
    }

    private void PlayWistle()
    {
        audioSource.PlayOneShot(wistle);
    }


}
