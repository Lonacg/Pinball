using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PinballFlipper : MonoBehaviour
{
    public new  Rigidbody rigidbody;
    public bool isLeftFlipper;
    public float rotationSpeed;
    private Quaternion initialRotation;


    public new HingeJoint hingeJoint;
    private JointSpring spring;




    // Start is called before the first frame update
    void Start()
    {
        initialRotation=rigidbody.rotation;
        spring=hingeJoint.spring;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MoveRotationMethod();
        JointMethod();

    }

    void JointMethod()
    {
        if (isLeftFlipper)
        {
            if(Keyboard.current.aKey.isPressed)
            {
                spring.targetPosition=-60;
            }
            else
            {
                spring.targetPosition=0;
            }
        }
        else
        {
            if(Keyboard.current.dKey.isPressed)
            {
                spring.targetPosition=60;
            }
            else
            {
                spring.targetPosition=0;
            }
        }
        hingeJoint.spring=spring;
    }





    void MoveRotationMethod()
    {
        Quaternion targetRotation=Quaternion.identity;
        if (isLeftFlipper)
        {
            if(Keyboard.current.aKey.isPressed)
            {
                targetRotation=Quaternion.Euler(x:0,y:-60,z:0); //rotamos
            }
        }
        else
        {
            if(Keyboard.current.dKey.isPressed)
            {
                targetRotation=Quaternion.Euler(0,60,0); //rotamos
            }
        }
        rigidbody.MoveRotation(rot:Quaternion.Lerp(a:rigidbody.rotation,b:initialRotation*targetRotation,t:Time.deltaTime*rotationSpeed));
        //move rotation añade la fuerza que considera necesaria para que en el siguiente frame este donde le hemos dicho
        //delta.time dentro del fixed update en realidad seria un fixed delt time

    }




}