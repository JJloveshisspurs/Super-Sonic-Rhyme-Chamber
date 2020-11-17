using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

using TMPro;

public class MusicalTargetController : MonoBehaviour
{
    public MusicalTargetData metronomeRap;

    public GameObject musicalTargetPrefab;

    public Transform targetStartPosition;

    public float musicalTargetEndPosition;

    public VerseData Doc_Agon_Verse;

    public VerseData Player_Verse;


    public int wordIndex;

    public int barIndex;


    public bool isItPlayersturn = false;

    public TextMeshPro VerseRenderedText;
    public TextMeshPro turnTitleRenderedText;

    public void Awake()
    {
        InitializeSongData();
    }


    public void InitializeSongData()
    {
        InvokeRepeating("SpawnMusicalTarget",0f, metronomeRap.targetSpawnRate);


    }

    public void SpawnMusicalTarget()
    {
        //*** Instantiate target at start position
        GameObject oMusicTarget = Instantiate(musicalTargetPrefab, targetStartPosition);

        MusicalTarget oTargetObject = oMusicTarget.GetComponent<MusicalTarget>();

        //*** Set the Text for the word
        oTargetObject.SetText(GetWord());

        // tween at specific movement speed
        oMusicTarget.transform.DOMoveX(musicalTargetEndPosition, metronomeRap.targetMoveTime);

        //*** Destory object with specific lifespan length here
        DestroyObject(oMusicTarget, metronomeRap.targetLifespan);


    }

    public string GetWord()
    {
        string oWord = "";

        if (isItPlayersturn == false) {

            turnTitleRenderedText.text = "Dr. Agon";

           

            //*** Iterate to next bar if rendered all words
            if (wordIndex == Doc_Agon_Verse.bars[barIndex].words.Count)
            {
                //*** move to next Bar, reset to first word
                barIndex++;
                wordIndex = 0;
                VerseRenderedText.text += "\n";
            }

                if (wordIndex < Doc_Agon_Verse.bars[barIndex].words.Count)
                {

                    oWord = Doc_Agon_Verse.bars[barIndex].words[wordIndex];

                }

            //*** Reset  after Agons Lines Finish , switch to player turn
            if (barIndex == 1 && wordIndex == 7)
            {
                barIndex = 0;
                wordIndex = 0;

                isItPlayersturn = true;
            }

        }
        else
        {

            if (turnTitleRenderedText.text == "Dr. Agon")
            {


                VerseRenderedText.text = "";
                barIndex = 0;
                wordIndex = 0;
            }


            turnTitleRenderedText.text = "Player";

           

           

            //*** Iterate to next bar if rendered all words
            if (wordIndex == Player_Verse.bars[barIndex].words.Count)
            {
                //*** move to next Bar, reset to first word
                barIndex++;
                wordIndex = 0;
                VerseRenderedText.text += "\n";
            }

            if (wordIndex < Player_Verse.bars[barIndex].words.Count)
            {

                oWord = Player_Verse.bars[barIndex].words[wordIndex];

            }
        }

        VerseRenderedText.text += " " + oWord;


        wordIndex++;

        return oWord;
    }



}
