using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class PunchlineParser : MonoBehaviour
{

    public static PunchlineParser instance;

    public string[] lineArray;

    private string[] delimitersArray = new string[] {" ","," };

    public List<KeywordData> keywords;

    public List<KeywordData> dataObject;

    public List<KeywordData> activeKeywords;

    public List<DisplayContainer> DisplayContainers;

    public int activeDisplayContainers;

    private void Awake()
    {
        if (instance == null) 
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void EvaluateLine(string pSentence)
    {
        Debug.Log("Evaluating Line Spoken !!!!");

        lineArray = new string[0];


        lineArray = pSentence.Split(delimitersArray, System.StringSplitOptions.RemoveEmptyEntries);


        //*** Figure out hwich keywords were activated
        ResolveKeywords();
    }


    public void ResolveKeywords()
    {
        Debug.Log("Beggining to Resolve Key Words !!!!");

        dataObject = new List<KeywordData>();
        activeKeywords = new List<KeywordData>();

        Debug.Log("Line length" + lineArray.Length.ToString());

        //*** iterate through words said 
        for ( int i = 0; i < lineArray.Length; i++)
        {
            //*** Initialize new data object list
            dataObject = new List<KeywordData>();


            //*** Search for object based on a special keyword
            dataObject = keywords.Where(x => x.targetedWord.ToUpper() == lineArray[i].ToUpper()).ToList();


            //*** If Data object is null  check the alternative keyword
            if(dataObject == null)
            {
                dataObject = keywords.Where(x => x.alternativeWord.ToUpper() == lineArray[i].ToUpper()).ToList();
            }

            if (dataObject == null)
            {
                Debug.Log("Data Object is still null !");
            }
            else
            {

                Debug.Log("Data Object size = " + dataObject.Count.ToString());

            }
            // modelsList = bundleDownloadClass.masterVehicleDataList.Data.OfType<MDLDownload.Datum>()
            //.Where(x => x.Make.ToUpper() == pVehicleName.ToUpper()).ToList();

            if (dataObject != null)
            {
                if(dataObject.Count > 0)
                activeKeywords.Add(dataObject[0]);

            }


        }

        HandleKeywords();

    }


    public void HandleKeywords()
    {
        Debug.Log("Handling Keywords !!!!");


        GameObject oPhysicalObject;
        GameObject oParticles;
        AudioClip oClip;




        for(int i = 0; i < DisplayContainers.Count; i++)
        {
            oPhysicalObject = null;
            oParticles = null;
            oClip = null;


            if (activeDisplayContainers > 4)
                activeDisplayContainers = 0;

                if (activeKeywords.Count > 0 && i < activeKeywords.Count)
            {

                if (activeKeywords[i] != null)
                {
                    oPhysicalObject = activeKeywords[i].physicalObject;
                    oParticles = activeKeywords[i].particle;
                    oClip = activeKeywords[i].audioClip;

                    //*** Display Effect !!!!
                    Debug.Log("Displaying " + activeKeywords[i].targetedWord + " / " + activeKeywords[i].alternativeWord);
                    DisplayContainers[activeDisplayContainers].SetEffects(oParticles, oPhysicalObject, oClip);
                    activeDisplayContainers++;
                }

            }

        }

    }
}
