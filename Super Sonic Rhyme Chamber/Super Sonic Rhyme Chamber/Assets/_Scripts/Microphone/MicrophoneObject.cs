using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicrophoneObject : MonoBehaviour
{

    public TextMeshProUGUI micStateText;

    private Vector3 startingPosition;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && StageExperienceManager.instance.Recording == false)
        {
            OnSelectEnter();

        }

        if (Input.GetKeyUp(KeyCode.Space) && StageExperienceManager.instance.Recording == true)
        {

            OnSelectExit();

        }
    }

    public void ActivateMic()
    {

        //StageExperienceManager.instance.BeginRecording();
        micStateText.text = "Microphone State : Activate Mic";
    }

    public void DeactivateMic()
    {
        micStateText.text = "Microphone State : Deactivate Mic";
        //StageExperienceManager.instance.FinishRecording();

    }

    public void OnFirstHover()
    {
        micStateText.text = "Microphone State : On First Hover";

    }

    public void OnHoverEnter()
    {
        micStateText.text = "Microphone State : On Hover Enter";

        //StageExperienceManager.instance.speechToTextService.ClearResultstextMesh();
    }

    public void OnHoverExit()
    {
        micStateText.text = "Microphone State : On Hover Exit";

    }

    

    public void OnLastHoverExit(){
        micStateText.text = "Microphone State : On Last Hover Exit";
    }

    public void OnSelectEnter()
    {
        micStateText.text = "Microphone State : On Select Enter";
        StageExperienceManager.instance.BeginRecording();
    }

    public void OnSelectExit()
    {
        micStateText.text = "Microphone State : On Select Exit";
        StageExperienceManager.instance.FinishRecording();

        StageExperienceManager.instance.ResetMicPosition();
    }

}
