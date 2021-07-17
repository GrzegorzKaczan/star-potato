using UnityEngine;
using System;
using System.Collections.Generic;

public class CircleInteractableController : MonoBehaviour, IInteractableController
{
    public Queue<ICommand> GetCommands(GameObject player)
    {
        return new Queue<ICommand>(new ICommand[] {
            new MoveCommand(player, transform),
            new PlayAnimationCommand(player, "PickUp", false),
            new PlayAnimationCommand(transform.gameObject, "PickUp", false)
        });
    }
}