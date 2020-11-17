using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class HeadphoneGrabSequence : SequenceModule_Base
{

    public GameObject headPhoneModel;

    public Vector3 headphonesMaxScale = Vector3.one;
    public Vector3 headphonesMinScale = Vector3.zero;
    public float headphoneScaleTweenTime = 3f;

    public AudioSource headphoneInteractionSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            Headphones_Grabbed();
    }


    public new void InitializeSequence()
    {

        Invoke("ExpandHeadPhones", 2f);

    }

    public new void CloseSequence()
    {
        Intro_Manager.instance.MoveToNextSequence();


    }

   public void ExpandHeadPhones()
    {

        headPhoneModel.SetActive(true);

        headPhoneModel.transform.DOScale(headphonesMaxScale, headphoneScaleTweenTime);

    }

    public void ShrinkHeadPhones()
    {
        headPhoneModel.transform.DOScale(headphonesMinScale, headphoneScaleTweenTime).onComplete += CloseSequence;

    }

    public void PlayInteractionSound()
    {

        headphoneInteractionSound.Play();
    }

    public void Headphones_Grabbed()
    {
        ShrinkHeadPhones();
        PlayInteractionSound();

    }
}
