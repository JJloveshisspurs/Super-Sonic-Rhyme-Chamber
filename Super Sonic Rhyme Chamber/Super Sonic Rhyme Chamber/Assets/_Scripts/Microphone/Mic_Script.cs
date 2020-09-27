using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic_Script : MonoBehaviour
{
    AudioSource AudioMic;

    public int ouputSampleRate = 44100;
    void Start()
    {
        Invoke("InitializeMic",5f);
    }

    public void InitializeMic()
    {

        StartCoroutine(CaptureMic());

    }



    IEnumerator CaptureMic()
    {
        if (AudioMic == null) AudioMic = GetComponent<AudioSource>();
        AudioMic.clip = Microphone.Start(null, true, 1, ouputSampleRate);
        AudioMic.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        Debug.Log("Start Mic(pos): " + Microphone.GetPosition(null));
        AudioMic.Play();

        //capture for live streaming
        //while (!stop)
        //{
        //    AddMicData();
        //    yield return null;
        //}
        //capture for live streaming
        yield return null;
    }
}
