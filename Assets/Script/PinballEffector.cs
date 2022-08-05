using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballEffector : MonoBehaviour
{
    public float impulse=10;
    public float noiseStrength;
    private Vector3 noise;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Rigidbody otherRigidBody=other.GetComponent<Rigidbody>();
            otherRigidBody.velocity= Vector3.zero;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            noise= transform.right*Random.Range(-noiseStrength, noiseStrength); //==> noise= new Vector3(Random.Range(-1f,1f), 0,0);

            Rigidbody otherRigidBody=other.GetComponent<Rigidbody>();
            otherRigidBody.AddForce((transform.forward+noise).normalized*impulse,ForceMode.Impulse);

        }
    }


}
