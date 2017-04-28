using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerptest : MonoBehaviour {

    float zMovement = 0.0f;
    float lerpFactor = .4f;
    float speed = 1;

    void Update()
    {
        zMovement = Mathf.Lerp(zMovement, (Input.GetAxis("TrolleyForward") / 50), lerpFactor * (Time.deltaTime * 6)) * speed;



        transform.Translate(0, 0, zMovement);

        print(zMovement);
    }
}
