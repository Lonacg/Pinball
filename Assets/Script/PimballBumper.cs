using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PimballBumper : MonoBehaviour
{
    // Start is called before the first frame update
    public float impulse=1;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.body.tag=="Player")
        {
            collision.rigidbody.AddForce(collision.impulse.normalized*impulse,ForceMode.Impulse);
        }
    }
}
