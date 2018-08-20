using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AttachToRobot : NetworkBehaviour {

    int netId;

    //public GameObject rosConnector;

    public PoseStampedPublisher left_arm;
    public PoseStampedPublisher right_arm;

    public GameObject leftController;
    public GameObject rightController;
    public GameObject robot1;

    private Message message;
    private RosSocket rosSocket;
    private string publicationIdLeft;
    private string publicationIdRight;

    public override void OnStartLocalPlayer()
    {
        // where to attach script/where is this script run?
        //print("Entered AttachToRobot.cs script");

        netId = (int)GetComponent<NetworkIdentity>().netId.Value;
        if (netId == 1)
        {
            // create poseStamped publisher on RosConnector1 for each controller, 
            // and fill it relavent method variables

            // if netID == 1 get ros connector 1, assign left arm published to be game component with topic of baxter_left controller
            // same thing with right controller
            //rosConnector = GameObject.Find("RosConnector1");

            rosSocket = GetComponent<RosConnector>().RosSocket;

            // proper way of getting components?
            PoseStampedPublisher[] publisherComponents = GetComponents<PoseStampedPublisher>();
            foreach(PoseStampedPublisher p in publisherComponents)
            {
                //print(p);
                if(p.Topic=="/baxter_left_controller")
                {
                    left_arm = p;
                    left_arm.PublishedTransform = leftController.transform;
                    //publicationIdLeft = rosSocket.Advertise<Message>(p.Topic);
                } else if(p.Topic=="/baxter_right_controller")
                {
                    right_arm = p;
                    right_arm.PublishedTransform = rightController.transform;
                    //publicationIdRight = rosSocket.Advertise<Message>(p.Topic);
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

        // left arm
        // how to check if left arm send button is pressed?
        if (Input.GetAxis("Left Grip") > 0.5f)
        {
            Debug.Log("updating left arm");
            left_arm.UpdateMessage();
            // how to publish?
            //rosSocket.Publish(publicationIdLeft, message);
        }
        // right arm
        if (Input.GetAxis("Right Grip") > 0.5f)
        {
            Debug.Log("updating right arm");
            right_arm.UpdateMessage();
            //rosSocket.Publish(publicationIdLeft, message);
        }
    }
}
