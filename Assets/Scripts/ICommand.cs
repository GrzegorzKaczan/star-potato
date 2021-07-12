using UnityEngine;
using System;

public interface ICommand
{
    public void Execute(Action doneCallback);
}
