using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{

    Transform headRigTransform;
    Transform leftControllerRigTransform;
    Transform rightControllerRigTransform;

    Transform headPlayerTransform;
    Transform leftControllerPlayerTransform;
    Transform rightControllerPlayerTransform;


    public override void OnStartLocalPlayer()
    {   
        headRigTransform = GameObject.Find("Camera (eye)").transform;
        leftControllerRigTransform = GameObject.Find("Controller (left)").transform;
        rightControllerRigTransform = GameObject.Find("Controller (right)").transform;

        headPlayerTransform = transform.Find("Head").transform;
        leftControllerPlayerTransform = transform.Find("LeftController").transform;
        rightControllerPlayerTransform = transform.Find("RightController").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        headPlayerTransform.position = headRigTransform.position;
        headPlayerTransform.rotation = headRigTransform.rotation;
        leftControllerPlayerTransform.position = leftControllerRigTransform.position;
        leftControllerPlayerTransform.rotation = leftControllerRigTransform.rotation;
        rightControllerPlayerTransform.position = rightControllerRigTransform.position;
        rightControllerPlayerTransform.rotation = rightControllerRigTransform.rotation;
    }
}
