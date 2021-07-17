using UnityEngine;
using System;
using System.Collections.Generic;

public interface IInteractableController
{
    Queue<ICommand> GetCommands(GameObject player);
}