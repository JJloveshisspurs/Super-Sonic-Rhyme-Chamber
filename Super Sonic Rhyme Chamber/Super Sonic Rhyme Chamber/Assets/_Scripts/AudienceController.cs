using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudienceController : MonoBehaviour
{

    public List<Transform> bounceGroupParents;

    public AudienceMemberMove[] audienceMembers;


    //*** All the parameters for bounce groups 
   [HeaderAttribute("Bounce Groups Tween values")]
    public float bounceHeight;

    public int minJumpNumber;
    public int maxJumpNumber;

    private float targetY;
    public float jumpPower = 1f;
    public int numOfJumps = 1000;
    public float jumpTime = 1f;

    private Vector3 jumpPositionVector;

    // Start is called before the first frame update
    void Start()
    {
        GetAudienceMembers();
    }

    public void GetAudienceMembers()
    {

        //*** Get all active audience member objects
        audienceMembers = GameObject.FindObjectsOfType<AudienceMemberMove>();

        AssignAudienceToBounceGroups();

    }

    public void AssignAudienceToBounceGroups()
    {
        //*** Seed we use to randomly distribute audience members into groups
        int oRandomSeed = 0;

        for (int i = 0; i < audienceMembers.Length; i++) {

            //*** get Random bounce group
             oRandomSeed   = Random.Range(0, bounceGroupParents.Count);

            //*** assign  current audience member to a parent group to bounce with
            audienceMembers[i].transform.parent = bounceGroupParents[oRandomSeed].transform;

        }

        //*** After setting all audience members , initialize boucne group movements
        InitializeBounceGroups();


    }

    private void InitializeBounceGroups()
    {

        GetTargetY();

        InitializeBounce();

    }


    public void SetNumberogJumps()
    {
        numOfJumps = Random.Range(minJumpNumber, maxJumpNumber);

    }

    public void GetTargetY()
    {
        targetY = this.gameObject.transform.position.y + bounceHeight;

    }

    public void InitializeBounce()
    {

        for (int i = 0; i < bounceGroupParents.Count; i++)
        {
            //*** Set Number of jumps which changes jump speed
            SetNumberogJumps();
            jumpPositionVector = new Vector3(this.gameObject.transform.position.x, targetY, this.gameObject.transform.position.z);

            bounceGroupParents[i].DOJump(jumpPositionVector, jumpPower, numOfJumps, jumpTime);
        }
    }
}
