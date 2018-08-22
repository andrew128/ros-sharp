using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AttachToRobot : MonoBehaviour {

    public PoseStampedPublisher left_arm;
    public PoseStampedPublisher right_arm;

    void Update () {

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
