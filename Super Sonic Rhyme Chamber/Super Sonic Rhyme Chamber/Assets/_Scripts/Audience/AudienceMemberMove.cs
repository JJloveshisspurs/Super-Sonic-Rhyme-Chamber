using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudienceMemberMove : MonoBehaviour
{
    public float bounceHeight;

    public int minJumpNumber;
    public int maxJumpNumber;

    private  float targetY;
    public float jumpPower = 1f;
    public int numOfJumps = 1000;
    public float jumpTime = 1f;

    private Vector3 jumpPositionVector;

    // Start is called before the first frame update
    void Start()
    {
       /* GetTargetY();
        SetNumberogJumps();
        InitializeBounce();*/

    }

    public void SetNumberogJumps()
    {
        numOfJumps = Random.Range(minJumpNumber,maxJumpNumber);
        
    }

    public void GetTargetY()
    {
        targetY = this.gameObject.transform.position.y + bounceHeight;

    }

    public void InitializeBounce()
    {
        jumpPositionVector = new Vector3(this.gameObject.transform.position.x, targetY, this.gameObject.transform.position.z);

        this.gameObject.transform.DOJump(jumpPositionVector, jumpPower, numOfJumps, jumpTime);
    }


}
