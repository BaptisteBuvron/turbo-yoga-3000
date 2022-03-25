using System.Collections;
using UnityEngine;

namespace Assets.Positions
{
    public static class PositionMatcher
    {

        public static float getPositionMatch(Position2 pose, Position2 playerPosition, float bodyHeight, float armLength)
        {

            armLength = bodyHeight / 2;

            float armHeight = bodyHeight - 0.30f;


            Position2 playerPositionNormalized = new Position2(new Vector2(playerPosition.headPosition.x*9f/1.75f, playerPosition.headPosition.y * 9f / 1.75f), new Vector2(playerPosition.leftHandPosition.x * 9f / 1.75f, playerPosition.leftHandPosition.y * 9f / 1.75f), new Vector2(playerPosition.rightHandPosition.x * 9f / 1.75f, playerPosition.rightHandPosition.y * 9f / 1.75f));

            /*
                float percentage; 

                Vector2 calibratedHeadPosition = new Vector2(playerPosition.headPosition.x * 9 / calibration.headPosition.x, playerPosition.headPosition.y * 9 / calibration.headPosition.y);
                Vector2 calibratedLeftHandPosition = new Vector2(playerPosition.leftHandPosition.x * 9 / calibration.leftHandPosition.x, playerPosition.leftHandPosition.y * 9 / calibration.leftHandPosition.y);
                Vector2 calibratedRightHandPosition = new Vector2(playerPosition.rightHandPosition.x * 9 / calibration.rightHandPosition.x, playerPosition.rightHandPosition.y * 9 / calibration.rightHandPosition.y);

                Position2 calibratedPlayerPosition = new Position2(calibratedHeadPosition, calibratedLeftHandPosition, calibratedRightHandPosition);

                percentage = pose.headPosition.x * calibratedPlayerPosition.headPosition.x;

            */

            float percentage, percentageHead, percentageLeftHand, percentageRightHand;

            Vector2 playerHeadCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.headPosition.x), Mathf.Abs(playerPositionNormalized.headPosition.y) * 9 / bodyHeight);

            Vector2 playerLeftHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.leftHandPosition.x)*9/ armLength, Mathf.Abs(playerPositionNormalized.leftHandPosition.y)*9/armHeight);
            
            Vector2 playerRightHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.rightHandPosition.x)*9/ armLength, Mathf.Abs(playerPositionNormalized.rightHandPosition.y) * 9/armHeight);


            percentageHead = (Mathf.Abs(playerHeadCalibrated.x - pose.headPosition.x) * 100 / 9);
            percentageHead += (Mathf.Abs(playerHeadCalibrated.y - pose.headPosition.y) * 100 / 9);
            percentageHead /= 2;

            if (percentageHead < 0)
            {
                percentageHead = 0;
            }
            if (percentageHead > 100)
            {
                percentageHead = 100;
            }

            Debug.Log("Tête : "+percentageHead+"%");

            percentageLeftHand = (Mathf.Abs(playerLeftHandCalibrated.x - pose.leftHandPosition.x) * 100 / 9);
            percentageLeftHand += (Mathf.Abs(playerLeftHandCalibrated.y - pose.leftHandPosition.y) * 100 / 9);
            percentageLeftHand /= 2;

            if (percentageLeftHand < 0)
            {
                percentageLeftHand = 0;
            }
            if (percentageLeftHand > 100)
            {
                percentageLeftHand = 100;
            }

            Debug.Log("Main gauche : " + percentageLeftHand + "%");

            percentageRightHand = (Mathf.Abs(playerRightHandCalibrated.x - pose.rightHandPosition.x) * 100 / 9);
            percentageRightHand += (Mathf.Abs(playerRightHandCalibrated.y - pose.rightHandPosition.y) * 100 / 9);
            percentageRightHand /= 2;

            if (percentageRightHand < 0)
            {
                percentageRightHand = 0;
            }
            if (percentageRightHand > 100)
            {
                percentageRightHand = 100;
            }

            Debug.Log("Main droite : " + percentageRightHand + "%");

            
            
            


            percentage = percentageHead + percentageLeftHand + percentageRightHand;
            percentage /= 3;

            return percentage;

        }
        
    }
}