using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneObject : MonoBehaviour
{

public void ActivateMic()
    {

        StageExperienceManager.instance.BeginRecording();

    }

    public void DeactivateMic()
    {

        StageExperienceManager.instance.FinishRecording();

    }

}
