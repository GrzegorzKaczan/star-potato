using System;
using System.Collections;
using System.Timers;
using UnityEngine;

public class MoveCommand : ICommand
{
    private GameObject targetWho;
    private Transform targetWhere;
    private Vector3 directVector;

    public MoveCommand(GameObject who, Transform where)
    {
        targetWho = who;
        targetWhere = where;
    }

    public MoveCommand(GameObject who, Vector3 where)
    {
        targetWho = who;
        directVector = where;
    }

    public Boolean isAsync() => false;

    public void Execute(Action OnComplete) {
        UnityEngine.Debug.Log("move: " + targetWho.GetType());
        
        MoveController controller = targetWho.GetComponent<MoveController>();
        Vector3 newPosition = targetWho.transform.position;
        if (controller) {
            if (targetWhere) {
                newPosition  = GetTargetPosition();
            } else {
                newPosition = directVector;
            }

            controller.SetTarget(newPosition, OnComplete);
        } else {
            UnityEngine.Debug.Log("Object " + targetWho.GetType().Name + " does not have MoveController attached.");
        }
    }

    public Vector3 GetTargetPosition() {
        Vector3 pos = targetWhere.position;
        InteractableTargetController target = targetWhere.GetComponentInChildren<InteractableTargetController>();

        if (target) {
            return target.GetTargetPosition();
        }
       
        return pos;
    }

}
