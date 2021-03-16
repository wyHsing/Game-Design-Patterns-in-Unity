using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    //Invoker provides command
    private Queue<Command> commandsQueue = new Queue<Command>();
    private Queue<ActionCommand> actionCommandQueue = new Queue<ActionCommand>();
    void Start()
    {

    }

    public void SaveCommand(Command _command)
    {
        commandsQueue.Enqueue(_command);
    }

    public void SaveCommand(ActionCommand _actionCommand)
    {
        actionCommandQueue.Enqueue(_actionCommand);
    }
    public void DoCommandInQueue()
    {
        while (commandsQueue.Count != 0)
        {
            commandsQueue.Peek().Execute();
            commandsQueue.Dequeue();
        }

        while(actionCommandQueue.Count != 0)
        {
            actionCommandQueue.Peek().Execute();
            actionCommandQueue.Dequeue();
        }
    }
}

