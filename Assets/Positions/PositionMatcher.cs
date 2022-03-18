using System.Collections;
using UnityEngine;

namespace Assets.Positions
{
    public static class PositionMatcher
    {

        public static float getPositionMatch(Position2 pose, Position2 playerPosition)
        {

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

            percentageHead = (Mathf.Abs(playerPositionNormalized.headPosition.x-pose.headPosition.x)*100/9);
            percentageHead += (Mathf.Abs(playerPositionNormalized.headPosition.y - pose.headPosition.y) * 100 / 9);
            percentageHead += (Mathf.Abs(playerPositionNormalized.headPosition.y - pose.headPosition.y) * 100 / 9);
            percentageHead /= 3;

            percentageLeftHand = (Mathf.Abs(playerPositionNormalized.leftHandPosition.x - pose.leftHandPosition.x) * 100 / 9);
            percentageLeftHand += (Mathf.Abs(playerPositionNormalized.leftHandPosition.y - pose.leftHandPosition.y) * 100 / 9);
            percentageLeftHand += (Mathf.Abs(playerPositionNormalized.leftHandPosition.y - pose.leftHandPosition.y) * 100 / 9);
            percentageLeftHand /= 3;

            percentageRightHand = (Mathf.Abs(playerPositionNormalized.rightHandPosition.x - pose.rightHandPosition.x) * 100 / 9);
            percentageRightHand += (Mathf.Abs(playerPositionNormalized.rightHandPosition.y - pose.rightHandPosition.y) * 100 / 9);
            percentageRightHand += (Mathf.Abs(playerPositionNormalized.rightHandPosition.y - pose.rightHandPosition.y) * 100 / 9);
            percentageRightHand /= 3;

            percentage = percentageHead + percentageLeftHand + percentageRightHand;
            percentage /= 3;

            return 100-percentage;

        }
        
    }
}