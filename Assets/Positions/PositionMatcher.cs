using System.Collections;
using UnityEngine;

namespace Assets.Positions
{
    public static class PositionMatcher
    {

        public static float getPositionMatch(Position2 pose, Position3 playerPosition, Position2 calibration)
        {

            float percentage;

            Vector2 calibratedHeadPosition = new Vector2(playerPosition.headPosition.x * 9 / calibration.headPosition.x, playerPosition.headPosition.y * 9 / calibration.headPosition.y);
            Vector2 calibratedLeftHandPosition = new Vector2(playerPosition.leftHandPosition.x * 9 / calibration.leftHandPosition.x, playerPosition.leftHandPosition.y * 9 / calibration.leftHandPosition.y);
            Vector2 calibratedRightHandPosition = new Vector2(playerPosition.rightHandPosition.x * 9 / calibration.rightHandPosition.x, playerPosition.rightHandPosition.y * 9 / calibration.rightHandPosition.y);

            Position2 calibratedPlayerPosition = new Position2(calibratedHeadPosition, calibratedLeftHandPosition, calibratedRightHandPosition);

            percentage = pose.headPosition.x * calibratedPlayerPosition.headPosition.x;


            return percentage;
        }
        
    }
}