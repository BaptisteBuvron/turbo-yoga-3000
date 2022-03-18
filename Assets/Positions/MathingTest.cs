using Assets.Positions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathingTest : MonoBehaviour
{

    

    void Start()
    {

        
    }


    void Update()
    {
        Position2 pose = new Position2(new Vector2(4.5f, 8.5f), new Vector2(2, 4), new Vector2(7, 4));

        Position3 playerPosition = new Position3(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));

        Position2 calibration = new Position2(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));

        Debug.Log("Pose � reproduire : T�te"+pose.headPosition+" Main gauche"+pose.leftHandPosition+" Main droite"+pose.rightHandPosition);
        Debug.Log("Calibration : T�te" + calibration.headPosition + " Main gauche" + calibration.leftHandPosition + " Main droite" + calibration.rightHandPosition);
        Debug.Log("Position du joueur : T�te" + playerPosition.headPosition + " Main gauche" + playerPosition.leftHandPosition + " Main droite" + playerPosition.rightHandPosition);

        Debug.Log("Correspondance des positions : "+PositionMatcher.getPositionMatch(pose, playerPosition, calibration) + "%");
    }
}
