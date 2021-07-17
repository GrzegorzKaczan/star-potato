using UnityEngine;
using System;

public interface ICommand
{
    Boolean isAsync();
    
    void Execute(Action doneCallback);
}
