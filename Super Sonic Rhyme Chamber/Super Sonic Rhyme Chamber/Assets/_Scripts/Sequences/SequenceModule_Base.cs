using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceModule_Base : MonoBehaviour
{

    //*** This is the core of the sequence system, each sequence inherits from this and will be called from the Intro_Manager


    public SequenceType.Sequence_Type sequence_Type;

    public Color BGColor;

    // Start is called before the first frame update
    void Start()
    {

    }



    public void InitializeSequence()
    {
        Debug.Log("Initializing Sequence: " + this.gameObject.name);


    }

    public void CloseSequence()
    {
        Debug.Log("Closing Sequence: " + this.gameObject.name);


    }




}
