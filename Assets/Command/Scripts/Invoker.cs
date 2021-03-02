using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    //Invoker provides command
    private Queue<Command> commandsQueue = new Queue<Command>();
    void Start()
    {

    }

    public void SaveCommand(Command _command)
    {
        commandsQueue.Enqueue(_command);
    }

    public void DoCommandInQueue()
    {
        while (commandsQueue.Count != 0)
        {
            commandsQueue.Peek().Execute();
            commandsQueue.Dequeue();
        }
    }
}

