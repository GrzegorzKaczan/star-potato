using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class MoveCommand : ICommand
{
    private GameObject targetWho;
    private Vector3 targetWhere;

    public MoveCommand(GameObject who, Vector3 where)
    {
        targetWho = who;
        targetWhere = where;
    }

    public void Execute(Action OnComplete) {
        UnityEngine.Debug.Log("move: " + targetWho.GetType());
        
        MoveController controller = targetWho.GetComponent<MoveController>();
        if (controller) {
            controller.SetTarget(targetWhere, OnComplete);
        } else {
            UnityEngine.Debug.Log("Object " + targetWho.GetType().Name + " does not have MoveController attached.");
        }
    }

}
