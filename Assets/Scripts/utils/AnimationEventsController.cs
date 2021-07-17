using UnityEngine;
using UnityEngine.Events;
using System;

[System.Serializable]
public class UnityAnimationEvent : UnityEvent<string>{};
[RequireComponent(typeof(Animator))]
public class AnimationEventsController : MonoBehaviour 
{
    public Action OnAnimationStart = delegate {};
    public Action OnAnimationComplete = delegate {};
    
    Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        for(int i=0; i<animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];
            
            AnimationEvent animationStartEvent = new AnimationEvent();
            animationStartEvent.time = 0;
            animationStartEvent.functionName = "AnimationStartHandler";
            animationStartEvent.stringParameter = clip.name;
            
            AnimationEvent animationEndEvent = new AnimationEvent();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = "AnimationCompleteHandler";
            animationEndEvent.stringParameter = clip.name;
            
            clip.AddEvent(animationStartEvent);
            clip.AddEvent(animationEndEvent);
        }
    }

    public void AnimationStartHandler(string name)
    {
        Debug.Log($"{name} animation start.");
        OnAnimationStart();
    }
    public void AnimationCompleteHandler(string name)
    {
        Debug.Log($"{name} animation complete.");
        OnAnimationComplete();
    }
}