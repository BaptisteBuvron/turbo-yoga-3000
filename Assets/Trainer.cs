using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Trainer : MonoBehaviour
{
  static Animator animator;
  bool playing = false;

  public static string lastAnimation = "Null";
  // Start is called before the first frame update

  private InputDevice targetDevice;
  private bool targetFound = false;
  private bool animationMethodAlreadyCalled = false;

  void Start()
  {
    animator = GetComponent<Animator>();

  }

  // Update is called once per frame
  void Update()
  {
    if (!targetFound)
    {
      List<InputDevice> devices = new List<InputDevice>();
      InputDeviceCharacteristics requiredCharacteristics =
          InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;
      InputDevices.GetDevicesWithCharacteristics(requiredCharacteristics, devices);

      if (devices.Count > 0)
      {
        targetDevice = devices[0];
        Debug.Log(targetDevice.name + " found");
        targetFound = true;
      }
      else
      {
        Debug.Log("No devices found");
      }
    }

    targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimaryButtonPressed);
    targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isSecondaryButtonPressed);
    if (isPrimaryButtonPressed && !playing)
    {
      playAnimation(Animations.Tpose);
    }
    else if (isSecondaryButtonPressed && !playing)
    {
      playAnimation(Animations.BrasParDessusTete);

    }
  }

  public static void playAnimation(Animations animation)
  {
    animator.SetInteger("id", ((int)animation));
  }
}

public enum Animations
{
  Tpose = 1,
  BrasParDessusTete = 2,
  Idle = 0
}