using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject hurtBox;
    [SerializeField] GameObject dogObj;
    PlayerMovementV1 dogVariables;
    private Vector2 hurtBoxPos;
    


    void Start()
    {
        dogVariables = dogObj.GetComponent<PlayerMovementV1>();
        hurtBoxPos = hurtBox.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempDogPos = new Vector2(dogVariables.transform.position.x, dogVariables.transform.position.y);
        hurtBox.transform.position = tempDogPos + dogVariables.controllerVect;




    }
}
