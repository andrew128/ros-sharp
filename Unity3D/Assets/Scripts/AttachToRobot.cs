using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AttachToRobot : NetworkBehaviour {

    int netId;

    //public GameObject rosConnector;

    private PoseStampedPublisher left_arm;
    private PoseStampedPublisher right_arm;

    public GameObject leftController;
    public GameObject rightController;
    public GameObject robot1;

    private Message message;
    private RosSocket rosSocket;
    private string publicationIdLeft;
    private string publicationIdRight;

    public override void OnStartLocalPlayer()
    {

        netId = (int)GetComponent<NetworkIdentity>().netId.Value;
        if (netId == 1)
        {
            // create poseStamped publisher on RosConnector1 for each controller, 
            // and fill it relavent method variables

            PoseStampedPublisher[] publisherComponents = GetComponents<PoseStampedPublisher>();
            foreach(PoseStampedPublisher p in publisherComponents)
            {
                if(p.Topic=="/baxter_left_controller")
                {
                    left_arm = p;
                    left_arm.PublishedTransform = leftController.transform;
                } else if(p.Topic=="/baxter_right_controller")
                {
                    right_arm = p;
                    right_arm.PublishedTransform = rightController.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        // if send button is depressed, update/publish each publisher created in start
        // call update message function from pose stamped published for each arm
        if (Input.GetAxis("Left Trigger") > 0.5f) {
            // left trigger
            Debug.Log("open left gripper");
        }
        if (Input.GetAxis("Right Trigger") > 0.5f) {
            // left trigger
            Debug.Log("open right gripper");
        }
        // left arm
        if (Input.GetAxis("Left Grip") > 0.5f)
        {
            Debug.Log("updating left arm");
            left_arm.UpdateMessage();
        }
        // right arm
        if (Input.GetAxis("Right Grip") > 0.5f)
        {
            Debug.Log("updating right arm");
            right_arm.UpdateMessage();
        }
    }
}
