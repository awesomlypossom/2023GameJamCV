using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private WolfWaypointFollower wayPointScript;
    // Start is called before the first frame update
    void Start()
    {
        wayPointScript = GetComponent<WolfWaypointFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
