using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPadForce : MonoBehaviour
{

    private float force = 20.0f;
    public Vector3 forceDirection = Vector3.zero;
    public bool boostEnabled;

    //private float lerpAmount = 0.05f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball" && boostEnabled == true)
        {
            Rigidbody rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            Vector3 forceVector = forceDirection;
            forceVector.x = 1;
            //rigidBody.velocity = direction;
            //rigidBody.AddRelativeForce(force,0,0);
            //rigidBody.AddForce(forceVector * force);
            //rigidBody.AddRelativeForce(direction, ForceMode.Impulse);
            //rigidBody.AddForce(direction, ForceMode.Impulse);
            Debug.Log("BoostPadEntered");

            
        }
    }
}
