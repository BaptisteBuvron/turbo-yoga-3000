using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
  Animator animator;
  bool playing = false;
  string lastAnimation = "Null";
  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.K) && !playing)
    {
      // StartAnimation(1, "BrasParDessusTete");
      TransitionToAnimation("BrasParDessusTete");
    }
    else if (Input.GetKeyDown(KeyCode.L) && !playing)
    {
      // StartAnimation(-1, "BrasParDessusTete");
      TransitionToAnimation("T-pose");
    }
    // Debug.Log(playing);
  }

  public void TransitionToAnimation(string nomAnimation)
  {
    if (lastAnimation != "Null")
    {
      Debug.Log("Reverse animation " + lastAnimation);
      float lastAnimationDuration = getAnimationDuration(lastAnimation);
      StartAnimation(-1, lastAnimation);
      StartCoroutine(Wait(lastAnimationDuration + 1, nomAnimation));
    }
    else
    {
      Debug.Log("Play animation " + nomAnimation);
      StartAnimation(1, nomAnimation);
    }

  }

  public void StartAnimation(int multiplier, string nomAnimation)
  {
    lastAnimation = multiplier == -1 ? "Null" : nomAnimation;
    animator.SetFloat("forward", multiplier);
    animator.Play(nomAnimation);
  }

  public void TogglePlaying(int fin)
  {
    playing = !playing;
    Debug.Log("playing " + playing);
  }
  IEnumerator Wait(float duration, string nextAnimation = "Null")
  {
    //This is a coroutine
    Debug.Log("Start Wait() function. The time is: " + Time.time);
    Debug.Log("Float duration = " + duration);
    yield return new WaitForSeconds(duration);   //Wait
    Debug.Log("End Wait() function and the time is: " + Time.time);
    Debug.Log("Now playing animation " + nextAnimation);
    StartAnimation(1, nextAnimation);
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