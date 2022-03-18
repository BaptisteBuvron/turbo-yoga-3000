using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PositionDetection : MonoBehaviour
{

    public XROrigin xrOrigin;
    public XRRayInteractor leftHand, rightHand;

    // Start is called before the first frame update
    void Start()
    {

        
    }


    // Update is called once per frame
    void Update()
    {

        

        Debug.Log("Main gauche : "+getLeftHandPosition());
        Debug.Log("Main droite : " + getRightHandPosition());
        Debug.Log("Tête : " + getHeadPosition());

    }

    Vector3 getHeadPosition()
    {
        return xrOrigin.Camera.transform.GetLocalPose().position;
    }

    Vector3 getLeftHandPosition()
    {
        return leftHand.transform.GetLocalPose().position;

    }
    Vector3 getRightHandPosition()
    {
        return rightHand.transform.GetLocalPose().position;

    }

}
