using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class PlayAnimationCommand : ICommand
{
    private GameObject gameObject;
    private string trigger; 
    private Boolean async = false;

    public PlayAnimationCommand(GameObject objectToAnimate, string animationTrigger, Boolean runCommandAsync)
    {
        gameObject = objectToAnimate;
        trigger = animationTrigger;
        async = runCommandAsync;
        
    }


    public Boolean isAsync() => async;


    public void Execute(Action OnComplete) {
        UnityEngine.Debug.Log("play_animation: " + "[" + trigger + "] on " + gameObject.GetType());
        
        Animator anim = gameObject.GetComponent<Animator>();
        AnimationEventsController animEvents = gameObject.GetComponent<AnimationEventsController>();

        if (anim && animEvents) {
            anim.SetTrigger(trigger);
            animEvents.OnAnimationComplete += () => {
                OnComplete();
            };
        } else {
            Debug.Log("Failed obtaining Animator or AnimationEventsController on " + ToString());
        }
    }
}
