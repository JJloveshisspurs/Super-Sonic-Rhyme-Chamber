using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class LetterDictionary : MonoBehaviour
{
    [SerializeField] GridLayoutGroup grid;
    public float scale = 1f;
    public float distanceLetter = .4f;
    [SerializeField] GameObject newWordObj;
    public List<string> letters = new List<string>();
    public List<GameObject> models3D = new List<GameObject>();
    Dictionary<string, GameObject> lettersDictionary = new Dictionary<string, GameObject>();

    public WatsonStreaming exampleStreaming;
    private void Start()
    {

        for (int i = 0; i < letters.Count; i++)
        {
            lettersDictionary.Add(letters[i], models3D[i]);
        }
        
     
     

    }

    private float spaceWord;
    private void MakeWord(string word)
    {
        
        GameObject newWord = (GameObject)Instantiate(newWordObj, transform.position, Quaternion.identity, grid.transform);
        
        spaceWord = newWord.transform.position.x;
        string[] characters = new string[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            GameObject goLetter = null;
            characters[i] = word[i].ToString();

            if (lettersDictionary.TryGetValue(characters[i], out goLetter))
            {

                Vector3 spacePos = new Vector3(newWord.transform.position.x + (spaceWord / (scale * 4f)), newWord.transform.position.y, newWord.transform.position.z);
                var dicLetter = Instantiate(goLetter, spacePos, Quaternion.Euler(0f, 180f, 0f), newWord.transform);
                dicLetter.transform.localScale = new Vector3(scale, scale, scale);

                //dicLetter.AddComponent<BoxCollider>();
                
                spaceWord += distanceLetter;
            }

        }

     
        
    }

   
   

    private void OnEnable()
    {
        if (exampleStreaming != null)
        {
            exampleStreaming.stopRecordEvent += MakeWordObject;
        }
    }

    private void OnDisable()
    {
        if (exampleStreaming != null)
        {
            exampleStreaming.stopRecordEvent -= MakeWordObject;
        }
    }

    private void MakeWordObject(string word)
    {
        String upper = word.ToUpper();
        MakeWord(upper);
        
    }

}
