using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExperienceManager : MonoBehaviour
{
    public static StageExperienceManager instance;


    public WatsonStreaming speechToTextService;


    public Transform microphone_transform;

    private Vector3 startingPosition;

    public enum performanceState
    {
        none,
        Recording,
        FinishedRecording,
        narrative
    }

    public performanceState currentPerformance;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void Start()
    {
        startingPosition = this.gameObject.transform.position;
    }

    public void BeginRecording()
    {

        speechToTextService.StartRecording();
    }


    public void FinishRecording()
    {
        speechToTextService.StopRecording();
        ResetMicPosition();


        StartCoroutine(DelayedEvaluate());
    }

    IEnumerator DelayedEvaluate()
    {
       
            yield return new WaitForSeconds(.25f);
        speechToTextService.EvaluateSentence();


    }

    public void ChangeMicrophoneState(performanceState pPerformanceState)
    {
        currentPerformance = pPerformanceState;


           
    }

    public void ResetMicPosition()
    {
        Debug.Log("Resetting !!!!");
        microphone_transform.position = startingPosition;
        microphone_transform.eulerAngles = Vector3.zero;
    }

    public void DelayedReset()
    {

        Invoke("ResetMicPosition",.75f);

    }
}
