using Assets.Positions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PositionDetection : MonoBehaviour
{

    public XROrigin xrOrigin;
    public XRRayInteractor leftHand, rightHand;

    public MonoBehaviour superText;
    public TextMeshProUGUI percentageDisplay;

    public float tailleJoueur;

    // Start is called before the first frame update
    void Start()
    {
        percentageDisplay.SetText("on start");

        PositionMatcher.xrOrigin = xrOrigin;
        PositionMatcher.leftHand = leftHand;
        PositionMatcher.rightHand = rightHand;

    }


    // Update is called once per frame
    void Update()
    {

        /*Debug.Log("Main gauche : " + getLeftHandPosition());
        Debug.Log("Main droite : " + getRightHandPosition());
        Debug.Log("Tête : " + getHeadPosition());*/


       

    }

    

}
