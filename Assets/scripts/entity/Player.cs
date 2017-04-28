using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Player controlled paddle
/// </summary>

public class Player : PaddleBase {
    //use this in inspector on your prefab to assign player?  Will that work?  Idfk.  *crosses fingers* -sjm
    public int playerNum = 1;

	// Use this for initialization
	public override void Start()
    {
        //playerNum = 1;
		base.Start();
		
		// Give the player faster movement
		SetThrust(20);
    }

    float zMovement = 0.0f;
    float lerpFactor = .4f;
    float speed = 1;

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        float deadzone = 0.25f;
        Vector2 stickInput = new Vector2(Input.GetAxis(playerNum + "Horizontal"), Input.GetAxis(playerNum + "Vertical"));
        if (stickInput.magnitude < deadzone)
            stickInput = Vector2.zero;
        else
        {
            stickInput = stickInput.normalized * ((stickInput.magnitude - deadzone) / (1 - deadzone));
            MovePaddles(stickInput.y);
        }
        

           
            //float vaxis = Mathf.Lerp(zMovement, (Input.GetAxis(playerNum + "Vertical") / 50), lerpFactor * (Time.deltaTime * 6)) * speed;
        //Debug.Log("vaxis = " + vaxis);

            // float haxis = Input.GetAxis(playerNum+"Horizontal");
            //float vaxis = Input.GetAxis(playerNum+"Vertical");

            //Local Multiplayer

            /*
            if (haxis != 0)
            {

            }
            
            if (vaxis != 0)
            {
                MovePaddles(vaxis);
            }
            */
            // If Fire1 is pressed, trigger pull animation
            //if (Input.GetButton("Fire1"))
            if (Input.GetButton(playerNum+"Fire1"))

        {
            animator.SetBool("pull", true);
            animator.SetBool("hit", true);
            SendInput(playerNum + "Fire1", true);
        }
        else
        {
            animator.SetBool("pull", false);
            animator.SetBool("hit", false);
            SendInput(playerNum + "Fire1", false);
        }
    }

    private new void Update()
    {
        base.Update();
        if (Input.GetButton(playerNum+"Fire2") && ( myPowers.Count > 0 || currentPowerName!=""))
        {
            TryActivate();
        }
        timeToNextMessage -= Time.deltaTime;

    }

    new public void TryActivate()
    {
        if (timeToNextMessage < 0)
        {
            timeToNextMessage = messageTimer;

            PaddleNetworking pn = GetComponent<PaddleNetworking>();
            if (!NetworkManager.singleton.isNetworkActive || NetworkServer.connections.Count > 0)
            {
                myPowers[myPowers.Count - 1].Activate();
                currentPowerName = "";
            }
            else
            {
                pn.CmdActivatePower();
                currentPowerName = "";
            }

            if (pn.isServer)
            {
                pn.RpcSetCurrentPower("");
            }

            if (!powerText)
            {
                GameObject powerUI = GameObject.FindGameObjectWithTag("PowerUp");
                powerText = powerUI.transform.GetChild(playerIndex).GetComponent<Text>();
            }

            powerText.text = "";
        }
    }
}
