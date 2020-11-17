using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCombatSequence : SequenceModule_Base
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public new void InitializeSequence()
    {

        Invoke("CloseSequence", 8f);

    }

    public new void CloseSequence()
    {
        MovetoNextSequence();

        this.gameObject.SetActive(false);
    }

    public void MovetoNextSequence()
    {

        Intro_Manager.instance.MoveToNextSequence();

    }
}
