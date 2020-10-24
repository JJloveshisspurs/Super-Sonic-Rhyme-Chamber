using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSpriteSheet : MonoBehaviour
{
    public SpriteRenderer renderer;
    public List<Sprite> AudienceAnimation;
    public float animationTime;

    private int animationIndex;



    public void Start()
    {
        InvokeRepeating("ChangeSprite", 0f, animationTime);
    }

    public void ChangeSprite()
    {
        if (animationIndex < AudienceAnimation.Count)
        {
            animationIndex++;
        }
        else
        {

            animationIndex = 0;
        }

        renderer.sprite = AudienceAnimation[animationIndex];

    }



}
