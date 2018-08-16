using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Transform headRigTransform;
    Transform leftControllerRigTransform;
    Transform rightControllerRigTransform;

    Transform headPlayerTransform;
    Transform leftControllerPlayerTransform;
    Transform rightControllerPlayerTransform;
    

	// Use this for initialization
	void Start () {
        headRigTransform = GameObject.Find("Camera (eye)").transform;
        leftControllerRigTransform = GameObject.Find("Controller (left)").transform;
        rightControllerRigTransform = GameObject.Find("Controller (right)").transform;

        headPlayerTransform = transform.Find("Head").transform;
        leftControllerPlayerTransform = transform.Find("LeftController").transform;
        rightControllerPlayerTransform = transform.Find("RightController").transform;
	}
	
	// Update is called once per frame
	void Update () {
        headPlayerTransform.position = headRigTransform.position;
        headPlayerTransform.rotation = headRigTransform.rotation;
        leftControllerPlayerTransform.position = leftControllerRigTransform.position;
        leftControllerPlayerTransform.rotation = leftControllerRigTransform.rotation;
        rightControllerPlayerTransform.position = rightControllerRigTransform.position;
        rightControllerPlayerTransform.rotation = rightControllerRigTransform.rotation;
	}
}
