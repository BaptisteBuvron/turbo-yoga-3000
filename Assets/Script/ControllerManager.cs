using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Script
{
    public class ControllerManager : MonoBehaviour
    {
        public static InputDevice leftController;
        public static InputDevice rightController;
        private bool AlltargetFound = false;
        

        void Update()
        {
            if (!AlltargetFound)
            {
                List<InputDevice> devicesLeft = new List<InputDevice>();
                List<InputDevice> devicesRight = new List<InputDevice>();
                InputDeviceCharacteristics requiredCharacteristicsRight =
                    InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;
                InputDeviceCharacteristics requiredCharacteristicsLeft =
                    InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;
                InputDevices.GetDevicesWithCharacteristics(requiredCharacteristicsRight, devicesRight);
                InputDevices.GetDevicesWithCharacteristics(requiredCharacteristicsLeft, devicesLeft);


                if (devicesLeft.Count > 0 && devicesRight.Count > 0)
                {
                    leftController = devicesLeft[0];
                    rightController = devicesRight[0];
                    AlltargetFound = true;
                    Debug.Log(leftController);
                }
                else
                {
                    Debug.Log("No devices found");
                }
            }
        }
    }
}