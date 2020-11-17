using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryIntroSequence : SequenceModule_Base
{
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public new void InitializeSequence()
    {
        BeginIntroSeuenceMusic();

      
    }

    public new void CloseSequence()
    {

        Intro_Manager.instance.MoveToNextSequence();

    }


    public void BeginIntroSeuenceMusic()
    {
        audio.Play();

        //*** end sequence based on audi clip length 
        Invoke("CloseSequence", audio.clip.length);
    }
}
