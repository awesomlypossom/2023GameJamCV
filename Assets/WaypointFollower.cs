using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    public float childSpeed = 2;
    public Vector2 totalVelocity = new Vector2(0,0);
    public float dogStreangth = 1f;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject dogObject;
    public int currWaypointIndex = 0;
    public Vector2 wayPointPos;
    public float leashLength = 3.0f;
    private Rigidbody2D rb;

    void waypointInfluence()
    {
        if (Vector2.Distance(wayPointPos, rb.position) >= .1)
        {
            totalVelocity = totalVelocity + ((wayPointPos - rb.position).normalized*childSpeed);
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

    void updateposition()
    {
        rb.velocity = totalVelocity;
    }

    void dogInflence()
    {
        Vector2 dogPosition = new Vector2(dogObject.transform.position.x,dogObject.transform.position.y);
        if (Vector2.Distance(dogPosition,rb.position)  >=leashLength ) 
        {
            totalVelocity = totalVelocity + ((dogPosition - rb.position).normalized) * dogStreangth;
        }
    }











    // Start is called before the first frame update
    void Start()
    {
        wayPointPos = waypoints[0].transform.position;
        rb = GetComponent<Rigidbody2D>() ;
        
    }

    // Update is called once per frame
    void Update()
    {
        totalVelocity.x = 0;
        totalVelocity.y = 0;
        waypointInfluence();
        dogInflence();




        updateposition();
        
    }
}
