using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxingWordSmithManager : MonoBehaviour
{
    //*** UI of timing notches
    public List<GameObject> timerNotches;

    //*** List of Hash code colors which will help indicate the damage or strength or the emphasis words. 
    public List<string> colorHashCodes;

    public TextMeshPro VerseRenderer;


    public string word1 = "";
    public string color1 = "";

    public string color2 = "";

    public string word2 = "";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RenderLine", 1f, 4f);
    }



    public void RenderLine()
    {

        //Test for randomly rendering hash codes colors
        int oRandomColor1 = Random.Range(0, 8);
        int oRandomColor2 = Random.Range(0, 8);

        color1 = colorHashCodes[oRandomColor1];
        color2 = colorHashCodes[oRandomColor2];


        string oWordReplacement = "<color=\"white\">You have no <color=#[color1]> [word1] <color=\"white\"> to compete with me I'll <color=#[color2]> [word2] <color=\"white\"> you and listen to my fans scream!</color>";

        oWordReplacement = oWordReplacement.Replace("[color1]", color1);

        oWordReplacement = oWordReplacement.Replace("[color2]", color2);

        VerseRenderer.text = oWordReplacement;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
