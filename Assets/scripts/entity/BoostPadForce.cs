using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPadForce : MonoBehaviour
{

    private float force = 10.0f;
    public Vector3 forceDirection = Vector3.zero;

    //private Vector3 myStartingScale = Vector3.zero;
    //private float scaleFactor = 1.2f;
    private float lerpAmount = 0.05f;

    /*private void Start()
    {
        myStartingScale = transform.localScale;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, myStartingScale, lerpAmount);
    }*/

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            Rigidbody rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            //Vector3 forceVector = rigidBody.transform.forward.normalized;
            Vector3 forceVector = forceDirection;
            forceVector.y = 0;
            rigidBody.AddForce(forceVector * force);

            /*Vector3 newScale = new Vector3(
                myStartingScale.x * scaleFactor,
                myStartingScale.y * scaleFactor,
                myStartingScale.z * scaleFactor);

            transform.localScale = newScale;*/
        }
    }
}
