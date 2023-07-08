using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfWaypointFollower : MonoBehaviour
{
    private Vector2 smoothInputRef;
    public float wolfSpeed = 2;
    private Vector2 totalVelocity = new Vector2(0,0);
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject kidObj;
    [SerializeField] GameObject attackTrigger;
    public int currWaypointIndex = 0;
    private Vector2 wayPointPos;
    private Rigidbody2D rb;
    public float dampingValue = .2f;
    public bool debugValue;
    public bool attackMode = false;
    private BoxCollider2D attackTriggerCollider;
    private BoxCollider2D kidCollider;

    void waypointInfluence()
    {
        if (Vector2.Distance(wayPointPos, rb.position) >= .1)
        {
            totalVelocity = totalVelocity + ((wayPointPos - rb.position).normalized*wolfSpeed);
        }
        else
        {
            currWaypointIndex++;
            if(currWaypointIndex >= waypoints.GetLength(0))
            {
                currWaypointIndex = 0;
            }
            wayPointPos =  waypoints[currWaypointIndex].transform.position;
        }
    }
    void checkKidDistance()
    {
        if(attackTriggerCollider.IsTouching(kidCollider))
        {
            attackMode = true;
        }
        debugValue = attackTriggerCollider.IsTouching(kidCollider);

    }
    void updateposition()
    {
        //rb.velocity = totalVelocity;
        rb.velocity = Vector2.SmoothDamp(rb.velocity,totalVelocity, ref smoothInputRef,dampingValue);
    }



    // Start is called before the first frame update
    void Start()
    {
        wayPointPos = waypoints[0].transform.position;
        rb = GetComponent<Rigidbody2D>() ;
        attackTriggerCollider = attackTrigger.GetComponent<BoxCollider2D>();
        kidCollider = kidObj.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        totalVelocity.x = 0;
        totalVelocity.y = 0;
        checkKidDistance();
        if(!attackMode)
        {
            waypointInfluence();
        }
        

        updateposition();
        
    }
}

