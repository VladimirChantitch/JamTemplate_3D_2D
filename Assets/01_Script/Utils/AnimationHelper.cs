using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    [SerializeField] Animator animator;
    Action onAnimationEnds;
    private bool isRunning;

    public void StartRunning()
    {
        if (!isRunning)
        {
            isRunning = true;
            animator.SetFloat("Speed", 1);
        }
    }

    public void StopRunnning()
    {
        if (isRunning)
        {
            isRunning = false;
            animator.SetFloat("Speed", 0);
        }
    }

    public void SpecialMovement()
    {
        animator.CrossFade("SpecialMovement", 0.15f);
        animator.SetBool("IsSpecialMotion", true);
        animator.Play("SpecialMovement");
    }

    public void StopSpecialMotion()
    {
        animator.SetBool("IsSpecialMotion", false);
    }

    public void PlayTargetAnimation(string animation)
    {
        animator.Play(animation);                                     
    }

    internal void PlayTargetAnimation(string animation, Action a)
    {
        animator.Play(animation);
        onAnimationEnds = a;
    }

    public void SetAnimationByBool(string boolNme, bool value)
    {
        animator.Play("Empty");
        animator.SetBool(boolNme, value);
    }

    public void OnAnimationEnds()
    {
        onAnimationEnds?.Invoke();
    } 
}
