using UnityEngine;
using System;
using System.Collections.Generic; 

public class DiamondInteractableController : MonoBehaviour, IInteractableController
{
    public Queue<ICommand> GetCommands(GameObject player) {
        return new Queue<ICommand>(new ICommand[] {
            new MoveCommand(player, transform.position),
            new MoveCommand(player, transform.position - new Vector3(-2, 0, 0)),
            new PickUpCommand(player, gameObject)
        });
    }
}