using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class PickUpCommand : ICommand
{
    private Transform itemObject;
    private GameObject playerObject;

    public PickUpCommand(GameObject player, Transform itemOnScene)
    {
        playerObject = player;
        itemObject = itemOnScene;
    }

    public Boolean isAsync() => false;
    

    public void Execute(Action OnComplete) {
        UnityEngine.Debug.Log("pickup: " + itemObject.GetType());
        
        UnityEngine.Object.Destroy(itemObject.gameObject);
        // add to inv
    }
}
