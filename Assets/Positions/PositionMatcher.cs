using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Assets.Positions
{
    public static class PositionMatcher
    {

        public static  XROrigin xrOrigin;
        public static XRRayInteractor leftHand, rightHand;

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

<<<<<<< Updated upstream
            */

            float percentage, percentageHead, percentageLeftHand, percentageRightHand;

            Vector2 playerHeadCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.headPosition.x), Mathf.Abs(playerPositionNormalized.headPosition.y) * 9 / bodyHeight);
=======
      Vector2 playerHeadCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.headPosition.x), Mathf.Abs(playerPositionNormalized.headPosition.y));

      Vector2 playerLeftHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.leftHandPosition.x), Mathf.Abs(playerPositionNormalized.leftHandPosition.y));

      Vector2 playerRightHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.rightHandPosition.x), Mathf.Abs(playerPositionNormalized.rightHandPosition.y));
>>>>>>> Stashed changes

            Vector2 playerLeftHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.leftHandPosition.x)*9/ armLength, Mathf.Abs(playerPositionNormalized.leftHandPosition.y)*9/armHeight);
            
            Vector2 playerRightHandCalibrated = new Vector2(Mathf.Abs(playerPositionNormalized.rightHandPosition.x)*9/ armLength, Mathf.Abs(playerPositionNormalized.rightHandPosition.y) * 9/armHeight);

<<<<<<< Updated upstream
=======
      percentageHead = (Mathf.Abs(playerHeadCalibrated.x - pose.headPosition.x*armLength * 2 / 9));
      percentageHead += (Mathf.Abs(playerHeadCalibrated.y - pose.headPosition.y * bodyHeight / 9));
      percentageHead /= 2;
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
            Debug.Log("Tête : "+percentageHead+"%");
             
            percentageLeftHand = (Mathf.Abs(playerLeftHandCalibrated.x - pose.leftHandPosition.x) * 100 / 9);
            percentageLeftHand += (Mathf.Abs(playerLeftHandCalibrated.y - pose.leftHandPosition.y) * 100 / 9);
            percentageLeftHand /= 2;
=======
      percentageLeftHand = (Mathf.Abs(playerLeftHandCalibrated.x - pose.leftHandPosition.x * armLength*2 / 9));
      percentageLeftHand += (Mathf.Abs(playerLeftHandCalibrated.y - pose.leftHandPosition.y * armLength * 2 / 9));
      percentageLeftHand /= 2;
>>>>>>> Stashed changes

            if (percentageLeftHand < 0)
            {
                percentageLeftHand = 0;
            }
            if (percentageLeftHand > 100)
            {
                percentageLeftHand = 100;
            }

            Debug.Log("Main gauche : " + percentageLeftHand + "%");

<<<<<<< Updated upstream
            percentageRightHand = (Mathf.Abs(playerRightHandCalibrated.x - pose.rightHandPosition.x) * 100 / 9);
            percentageRightHand += (Mathf.Abs(playerRightHandCalibrated.y - pose.rightHandPosition.y) * 100 / 9);
            percentageRightHand /= 2;
=======
      percentageRightHand = (Mathf.Abs(playerRightHandCalibrated.x - pose.rightHandPosition.x * armLength * 2 / 9));
      percentageRightHand += (Mathf.Abs(playerRightHandCalibrated.y - pose.rightHandPosition.y * armLength * 2 / 9));
      percentageRightHand /= 2;
>>>>>>> Stashed changes

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

        public static float getCurrentPercentage()
        {
            Position2 pose;

            switch (Trainer.lastAnimation)
            {
                case "BrasParDessusTete":

                    pose = new Position2(new Vector2(4.5f, 8.5f), new Vector2(3, 10), new Vector2(6, 10));
                    Debug.Log("Position : Bras par dessus la tête");
                    break;
                case "T-pose":
                    pose = new Position2(new Vector2(4.5f, 8.5f), new Vector2(2, 7f), new Vector2(7, 7f));
                    Debug.Log("Position : T-Pose");
                    break;
                default:
                    Debug.Log("Position : Aucune");
                    return 0;
                 break;
            }


            Position2 playerPosition = new Position2(new Vector2(getHeadPosition().x, getHeadPosition().y), new Vector2(getLeftHandPosition().x, getLeftHandPosition().y), new Vector2(getRightHandPosition().x, getRightHandPosition().y));

            return getPositionMatch(pose, playerPosition, 1.68f, 0.8f);
        }

        public static Vector3 getHeadPosition()
        {
            return xrOrigin.Camera.transform.GetLocalPose().position;
        }

        public static Vector3 getLeftHandPosition()
        {
            return leftHand.transform.GetLocalPose().position;
        }

        public static Vector3 getRightHandPosition()
        {
            return rightHand.transform.GetLocalPose().position;
        }

    }
}