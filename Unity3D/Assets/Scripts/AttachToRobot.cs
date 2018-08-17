using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AttachToRobot : NetworkBehaviour {

    int netId;

    public override void OnStartLocalPlayer()
    {
        netId = (int)GetComponent<NetworkIdentity>().netId.Value;
        if (netId == 1)
        {
            // create poseStamped publisher on RosConnector1 for each controller, 
            // and fill it relavent method variables
        }
    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        // if send button is depressed, update/publish each publisher created in start
    }
}
