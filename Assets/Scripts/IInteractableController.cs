using UnityEngine;
using System;
using System.Collections.Generic; 

public interface IInteractableController
{
    public Queue<ICommand> GetCommands(GameObject player);
}