using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class PickUpCommand : ICommand
{
    private GameObject itemObject;
    private GameObject playerObject;

    public PickUpCommand(GameObject player, GameObject itemOnScene)
    {
        playerObject = player;
        itemObject = itemOnScene;
    }

    public void Execute(Action OnComplete) {
        UnityEngine.Debug.Log("pickup: " + itemObject.GetType());
        
        playerObject.GetComponent<Animator>().SetTrigger("PickUp");
        playerObject.GetComponent<AnimationEventsController>().OnAnimationComplete += () => {
            UnityEngine.Object.Destroy(itemObject);
            OnComplete();
        };

        
    }
}
