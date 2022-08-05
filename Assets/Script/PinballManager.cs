using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinballManager : MonoBehaviour
{

    public float impulse=30f;
    public Rigidbody ballRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ballRigidbody.AddForce(transform.forward*impulse,ForceMode.Impulse);
        }

    }
}
