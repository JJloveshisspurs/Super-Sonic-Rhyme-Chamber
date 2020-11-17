using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundSphereController : MonoBehaviour
{

    public Material backgroundMaterial;

    public float colorChangetime;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void BackgroundColorChanger(Color pColor)
    {
        backgroundMaterial.DOColor(pColor, colorChangetime);


    }

    public void ForceColorChanger(Color pColor)
    {
        backgroundMaterial.color = pColor;


    }
}
