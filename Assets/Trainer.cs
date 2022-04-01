using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Trainer : MonoBehaviour
{
  static Animator animator;
  bool playing = false;

  public static Animations lastAnimation = Animations.Idle;
  // Start is called before the first frame update

  private InputDevice targetDevice;
  private bool targetFound = false;

  void Start()
  {
    animator = GetComponent<Animator>();

  }

  // Update is called once per frame
  public static void playAnimation(Animations animationId)
  {
    animator.SetInteger("id", ((int)animationId));
    lastAnimation = animationId;
  }

  private static Animations getRandomAnimation()
  {
    return (Animations)Random.Range(1, System.Enum.GetValues(typeof(Animations)).Length);
  }

  public static void playRandomAnimation()
  {
    Animations nextAnimationId;
    do
    {
      nextAnimationId = getRandomAnimation();
    } while (lastAnimation == nextAnimationId);
    playAnimation(nextAnimationId);
  }
}

public enum Animations
{
  Idle = 0,
  BrasParDessusTete = 1,
  Tpose = 2,
  BrasAngle = 3,
  BrasBas = 4,

}