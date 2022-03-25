using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Trainer : MonoBehaviour
{
  Animator animator;
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
      TransitionToAnimation("BrasParDessusTete");
    }
    else if (isSecondaryButtonPressed && !playing)
    {
      TransitionToAnimation("T-pose");
    }
  }

  public void TransitionToAnimation(string nomAnimation)
  {
    foreach (var animatorParameter in animator.parameters)
    {
      if (animatorParameter.type == AnimatorControllerParameterType.Bool)
      {
        animator.SetBool(animatorParameter.name, false);
      }
    }

    animator.SetBool(nomAnimation, true);
  }

  public List<string> getAnimationsName()
  {
    AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
    List<string> list = new List<string>();
    foreach (AnimationClip clip in clips)
    {
      list.Add(clip.name);
    }

    return list;
  }
}