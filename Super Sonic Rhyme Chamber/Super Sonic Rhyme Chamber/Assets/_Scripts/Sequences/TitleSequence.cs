using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleSequence : SequenceModule_Base
{
    //*** This will be our first Sequence Which reveals our title text

    public Transform titleLabel;

    public Vector3 maxTitlescale;
    public Vector3 minTitleScale;

    public float tweenInTime;
    public float tweenOutTime;

    //*** How long should our player jsut see the world/ title?
    public float titleRevealtime = 5f;


    public new void  InitializeSequence()
    {
        Debug.Log("Initializing Title Sequence!!!!");

        ExpandTitle();

    }

    public new void CloseSequence()
    {

        ShrinkTitle();

    }

    public void ExpandTitle()
    {

        titleLabel.DOScale(maxTitlescale, tweenInTime).onComplete += TitleExpanded;
    }


    public void ShrinkTitle()
    {
        titleLabel.DOScale(minTitleScale, tweenInTime).onComplete += TitleClosed;
    }


    public void  TitleExpanded()
    {
        Debug.Log("Title screen is visible!!!!");

        Invoke("ShrinkTitle", titleRevealtime);
    }


    public void TitleClosed()
    {
        Intro_Manager.instance.MoveToNextSequence();

    }
}
