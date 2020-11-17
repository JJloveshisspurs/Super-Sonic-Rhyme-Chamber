using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicalTarget : MonoBehaviour
{
    public TextMeshPro textLabel;

   public void SetText(string pWord)
    {

        textLabel.text = pWord;

    }
}
