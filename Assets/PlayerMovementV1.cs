using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class PlayerMovementV1 : MonoBehaviour
{
    public float dogStrength = 1f;
    public float speedCurr = 3;
    public float maxVel = 10;
    public float walkSpeed = 10;
    public float sprintSpeed = 20;
    private Rigidbody2D rb;
    public Vector2 controllerVect;
    private Vector2 controlVector;
    [SerializeField] GameObject kidObject;
    WaypointFollower kidObjVars;
    private Rigidbody2D kidObjectrb;
    private Vector2 smoothInputRef;
    public Vector2 tempVar;
    public float dampingValue = .2f;
    public float dogPullingSpeed = 2f;
    public float doggieDistance;

    void updateSpeed(Vector2 controlVect)
    { 
        Vector2 currVel = rb.velocity;
        Vector2 newVel = (controlVect * speedCurr + currVel);
        if(newVel.magnitude < maxVel)
        {
            rb.velocity = Vector2.SmoothDamp(currVel,newVel, ref smoothInputRef,dampingValue);
        }
    }
    Vector2 getControls()
    {    
        if(Input.GetKey("space"))
        {
            maxVel = sprintSpeed;
        }
        else
        {
            maxVel = walkSpeed;
        }
        Vector2 controlVect = new Vector2(0,0);
        if(Input.GetKey("w"))
        {
            controlVect[1] = controlVect[1] + 1;
        }

        if(Input.GetKey("a"))
        {
            controlVect[0] = controlVect[0] - 1;
        }

        if(Input.GetKey("s"))
        {
            controlVect[1] = controlVect[1] - 1;
        }

        if(Input.GetKey("d"))
        {
            controlVect[0] = controlVect[0] + 1;
        }
        controllerVect = controlVect;
        return controlVect;
    }
    void leashInfluance()
    {
        if(Vector2.Distance(kidObjectrb.position,rb.position) >= kidObjVars.leashLength)
        { 
            if(Vector2.Distance(kidObjectrb.position,rb.position) >= kidObjVars.leashLength*1.5)
            {
                tempVar = (kidObjectrb.position - rb.position).normalized;
                controlVector = (controlVector + tempVar*2).normalized;
            }
            else
            {
                tempVar = (kidObjectrb.position - rb.position).normalized;
                controlVector = (controlVector + tempVar).normalized;
                //maxVel = dogPullingSpeed;
            }
            
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() ;
        kidObjectrb = kidObject.GetComponent<Rigidbody2D>();
        kidObjVars = kidObject.GetComponent<WaypointFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        controlVector = getControls();
        leashInfluance();
        updateSpeed(controlVector);
        doggieDistance = Vector2.Distance(kidObjectrb.position,rb.position);
        
        
        
        
        
        if(Input.GetKey("space"))
        {
            maxVel = sprintSpeed;
        }
        else
        {
            maxVel = walkSpeed;
        }
    }


}
