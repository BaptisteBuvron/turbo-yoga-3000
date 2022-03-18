using Assets.Positions;
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

        Debug.Log("Main gauche : " + getLeftHandPosition());
        Debug.Log("Main droite : " + getRightHandPosition());
        Debug.Log("Tête : " + getHeadPosition());


        Position2 pose;

        switch (Trainer.lastAnimation)
        {
            case "BrasParDessusTete":

                pose = new Position2(new Vector2(4.5f, 8.5f), new Vector2(3, 10), new Vector2(6, 10));

                break;

            case "T-pose":

                pose = new Position2(new Vector2(4.5f, 8.5f), new Vector2(2, 8.5f), new Vector2(7, 8.5f));


                break;
            default:
                return;
                break;
        }


        Position2 playerPosition = new Position2(new Vector2(getHeadPosition().x, getHeadPosition().y), new Vector2(getLeftHandPosition().x, getLeftHandPosition().y), new Vector2(getRightHandPosition().x, getRightHandPosition().y));

        //Position2 calibration = new Position2(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));

        Debug.Log("Pose à reproduire : Tête" + pose.headPosition + " Main gauche" + pose.leftHandPosition + " Main droite" + pose.rightHandPosition);
        //Debug.Log("Calibration : Tête" + calibration.headPosition + " Main gauche" + calibration.leftHandPosition + " Main droite" + calibration.rightHandPosition);
        Debug.Log("Position du joueur : Tête" + playerPosition.headPosition + " Main gauche" + playerPosition.leftHandPosition + " Main droite" + playerPosition.rightHandPosition);

        Debug.Log("Correspondance des positions : " + PositionMatcher.getPositionMatch(pose, playerPosition) + "%");

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
