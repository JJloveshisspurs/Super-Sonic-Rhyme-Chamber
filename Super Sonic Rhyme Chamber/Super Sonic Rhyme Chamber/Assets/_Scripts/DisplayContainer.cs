using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayContainer : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject ParticleSystem;

    public GameObject physicalObject;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetEffects(GameObject pParticles = null, GameObject pObject = null, AudioClip pClip = null)
    {
        if (pParticles != null)
        {
            pParticles.transform.parent = this.gameObject.transform;

            pParticles.transform.localPosition = Vector3.zero;

            pParticles.SetActive(true);
        }

        if (pObject != null)
        {
            pObject.transform.parent = this.gameObject.transform;

            pObject.transform.localPosition = Vector3.zero;

            pObject.SetActive(true);
        }

        if (pClip != null)
        {
            audioSource.clip = pClip;

            audioSource.Play();


        }

    }
}
