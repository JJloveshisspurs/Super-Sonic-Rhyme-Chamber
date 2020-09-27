using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExperienceManager : MonoBehaviour
{
    public static StageExperienceManager instance;


    public WatsonStreaming speechToTextService;



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
       
    }

    public void BeginRecording()
    {

        currentPerformance = performanceState.Recording;

    }


    public void FinishRecording()
    {
        currentPerformance = performanceState.FinishedRecording;
        StartCoroutine(DelayedRecording());

    }

    IEnumerator DelayedRecording()
    {
        if (StageExperienceManager.instance.currentPerformance == StageExperienceManager.performanceState.Recording)
            yield return new WaitForSeconds(.25f);
        speechToTextService.EvaluateSentence();


    }
}
