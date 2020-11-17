using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Manager : MonoBehaviour
{
    public static Intro_Manager instance;

    //*** List of vearious sequential elements for our Intro tutorial
    public List<SequenceModule_Base> sequences;

    public GameObject SequenceContainer;

    public float experienceDelayedStart;

    public BackgroundSphereController backgroundController;


    public int currentSequenceIndex;

    public void Start()
    {
        if (instance == null) 
        instance = this;


        //*** Reset oriiginal colors
        backgroundController.ForceColorChanger(sequences[0].BGColor);

        Invoke("BeginIntroSequence", experienceDelayedStart);
    }

    public void BeginIntroSequence()
    {
        Debug.Log("Beginning Intro Sequence!!!!");

        currentSequenceIndex = 0;

        //*** Begin very first Sequence
        sequences[0].gameObject.SendMessage("InitializeSequence");
       
    }


    public void MoveToNextSequence()
    {

        if (sequences[currentSequenceIndex] != null)
            sequences[currentSequenceIndex].gameObject.SetActive(false);


        Debug.Log("Moving to Next Sequence!!!!");

        currentSequenceIndex++;

        //*** Activate Sequence game Object
        sequences[currentSequenceIndex].gameObject.SetActive(true);

        sequences[currentSequenceIndex].gameObject.SendMessage("InitializeSequence");

        backgroundController.BackgroundColorChanger(sequences[currentSequenceIndex].BGColor);


    }


    public void ResetExperience()
    {



    }
}
