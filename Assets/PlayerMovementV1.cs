using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class PlayerMovementV1 : MonoBehaviour
{
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
        Vector3 currVel = GetComponent<Rigidbody2D>().velocity;
        Vector3 newVel = (controlVect * speedCurr + currVel);
        if(newVel.magnitude < maxVel)
        {
            GetComponent<Rigidbody2D>().velocity = newVel;
        }
    }
    Vector3 getControls()
    {
        Vector3 controlVect = new Vector3(0,0,0);
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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("helloWorld");
        
    }

    // Update is called once per frame
    void Update()
    {
        updateSpeed(getControls());
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
