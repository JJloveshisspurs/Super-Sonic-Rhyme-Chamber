using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeactivate : MonoBehaviour
{

    public float timeToDeactivate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("DelayedDeactivate",timeToDeactivate);
    }


    public void DelayedDeactivate()
    {
        //*** Deactive this game object 
        this.gameObject.SetActive(false);
    }

}
