using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerActivator : MonoBehaviour
{
    public bool boostEnabled;
    public GameObject boost;

    private void Start()
    {
        boost.GetComponent<BoostPadForce>().enabled = false;
        boost.GetComponent<BoostPad>().lightDisabled();

    }

    void OnCollisionEnter(Collision col)
    {
        if (boostEnabled == true)
        {
            boost.GetComponent<BoostPadForce>().enabled = false;
            boost.GetComponent<BoostPad>().lightDisabled();
        }
        else if (boostEnabled == false)
        {
            boost.GetComponent<BoostPadForce>().enabled = true;
            boost.GetComponent<BoostPad>().lightEnabled();
        }


    }

}
