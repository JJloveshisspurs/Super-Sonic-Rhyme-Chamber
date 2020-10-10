using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineDeliveryandScorer : MonoBehaviour
{
    //*** Lyrics list
    public List<LyricData> lyrics;


    //*** array of words
    public string[] activeWords;


    //*** array of words from player
    public string[] playerWords;

    public List<string> wordsAlreadyScored;

    public TextMeshPro targetLyrics;
    public TextMeshPro playerLyrics;
    public TextMeshPro TotalLineScoreLabel;

    public int lineIndex;

    public int score;

    //*** trying to make sure we don't have duplicate things happening.
    public bool evaluationLocked;

    //*** Charactr delimeters , ways we split the string
    char[] delimitedChars ={' '};

    private void Start()
    {
        InitializeRhyme();
    }

    public void InitializeRhyme()
    {
        lineIndex = 0;

        RenderBar();
    }

    public void RenderBar()
    {
        //*** Set the active line for player to repeat
        targetLyrics.text = lyrics[lineIndex].lyricsToRender;

        //*** Break down lyrics into individual words
        BreakdownBarIntoArray();
    }

    public void BreakdownBarIntoArray()
    {
        activeWords = lyrics[lineIndex].lyricsToScore.Split(delimitedChars);
    }



    public void ScorePlayerLines(string pPlayerSpeech)
    {
        Debug.Log(" player line scoring == " + pPlayerSpeech);
        if (evaluationLocked == false)
        {
            evaluationLocked = true;


            //*** Breake down player Lines
            playerWords = pPlayerSpeech.Split(delimitedChars);

            //*** Iterate through all of the words in our current lyrics
            for (int i = 0; i < activeWords.Length; i++)
            {
                for (int x = 0; x < playerWords.Length; x++)
                {
                    //*** If word spoken matches word from original line
                    if (activeWords[i] == playerWords[x])
                    {
                        PlayerScored();

                    }



                }


            }

            ShowFinalLineScore();
        }
    }

    public void MoveToNextLine()
    {
        if (lineIndex < lyrics.Count)
        {
            lineIndex++;
        }
        else
        {
            lineIndex = 0;

        }

        //*** render nextbar
        RenderBar();
    }


    public void PlayerScored()
    {
        Debug.Log("Player Scored !!!");
        score += 10;

    }

    public void ShowFinalLineScore()
    {
        evaluationLocked = false;
        TotalLineScoreLabel.text = score.ToString();
        CancelInvoke();
        Invoke("MoveToNextLine", 3f);
    }
}
