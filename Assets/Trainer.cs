using System.Collections;
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
        //Debug.Log(isPrimaryButtonPressed + "" + isSecondaryButtonPressed);
    }

    public void TransitionToAnimation(string nomAnimation)
    {
        if (!animationMethodAlreadyCalled)
        {
            animationMethodAlreadyCalled = true;

            if (lastAnimation != "Null")
            {
                StartCoroutine(ReverseAndPlayNextAnimation(nomAnimation));
            }
            else
            {
                StartCoroutine(PlayAnimation(nomAnimation));
            }
        }
        else
        {
            return;
        }
    }

    public IEnumerator PlayAnimation(string animationName)
    {
        Debug.Log("Début animation " + animationName);
        animator.Play(animationName);
        yield return new WaitForSecondsRealtime(getAnimationDuration(animationName) + 2);
        Debug.Log("fin animation " + animationName);
        animationMethodAlreadyCalled = false;
        lastAnimation = animationName;

    }

    public IEnumerator ReverseAndWait()
    {
        Debug.Log("Début reverse" + lastAnimation);
        animator.SetFloat("forward", -1);
        animator.Play(lastAnimation);
        yield return new WaitForSeconds(getAnimationDuration(lastAnimation)*2.5f);
        animator.SetFloat("forward", 1);
        Debug.Log("Fin reverse" + lastAnimation);
    }

    public IEnumerator ReverseAndPlayNextAnimation(string nextAnimationName)
    {
        Debug.Log("Début fonction ReverseandPlayNextAnimation");
        yield return ReverseAndWait();
        //yield return new WaitForSeconds(1);
        yield return PlayAnimation(nextAnimationName);
    }


    public void TogglePlaying(int fin)
    {
        playing = !playing;
        Debug.Log("playing is now" + playing);
    }

    public float getAnimationDuration(string nomAnimation)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == nomAnimation)
            {
                return clip.length;
            }
        }

        Debug.LogError("Animation " + nomAnimation + " not found");
        return 10;
    }
}