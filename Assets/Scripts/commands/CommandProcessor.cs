using UnityEngine;
using System;
using System.Collections.Generic;

public class CommandProcessor
{
    public delegate void DoneDelegate();
    public DoneDelegate doneCallback;

    private Queue<ICommand> commands = new Queue<ICommand>();

    public void Add(ICommand command)
    {
        UnityEngine.Debug.Log("add: " + commands.Count);
        commands.Enqueue(command);

        if (commands.Count == 1)
        {
            ExecuteNextCommand();
        }
    }

    public void Add(Queue<ICommand> newCommands)
    {
        do
        {
            Add(newCommands.Dequeue());
        } while (newCommands.Count > 0);
    }

    private void ExecuteNextCommand()
    {
        UnityEngine.Debug.Log("check next ");
        if (commands.Count > 0)
        {
            ICommand nextCommand = commands.Peek();
            UnityEngine.Debug.Log("get next ");

            if (nextCommand != null)
            {
                UnityEngine.Debug.Log("execute next");
                nextCommand.Execute(OnCommandComplete);
            }
        }
    }

    private void OnCommandComplete()
    {
        UnityEngine.Debug.Log("Command completed");

        commands.Dequeue();
        ExecuteNextCommand();
    }
}