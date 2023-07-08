using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currWaypointIndex = 0;
    public Vector2 wayPointPos;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        wayPointPos = waypoints[0].transform.position;
        rb = GetComponent<Rigidbody2D>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPointPos != rb.position)
        {
            rb.velocity = (wayPointPos - rb.position)*.1f;
        }
    }
}
