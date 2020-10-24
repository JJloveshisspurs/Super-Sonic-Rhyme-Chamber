using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMemberSelector : MonoBehaviour
{

    public List<GameObject> characters;

    // Start is called before the first frame update
    void Start()
    {
        RandomlyAssignCharacter();
    }

    public void RandomlyAssignCharacter()
    {
        int i = Random.Range(0, characters.Count);

        characters[i].SetActive(true);

    }
}
