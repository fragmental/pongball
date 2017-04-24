using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPadForce : MonoBehaviour
{
    private float force = 0.25f;
    public Vector3 forceDirection = Vector3.zero;
    public bool boostEnabled;

    Vector3 forceVector;
    Vector3 forward = new Vector3(-1, 0, 0);

    private void Update()
    {
        forceVector = transform.rotation * forward;
        forceVector.y = 0;

        // Assign forceDirection so we can see it in the editor, this can be removed.
        forceDirection = forceVector;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball" && boostEnabled == true)
        {
            Rigidbody rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            rigidBody.AddRelativeForce(forceVector.normalized * force, ForceMode.Impulse);

            Debug.Log("BoostPadEntered");
        }
    }
}