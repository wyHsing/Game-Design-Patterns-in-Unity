using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayActionCommand : ActionCommand
{
    private Invoker m_Invoker;
    public ReplayActionCommand(Invoker _invoker)
    {
        m_Invoker = _invoker;
        SetAction = new ReplayAction();
    }

    public override void Execute()
    {
        m_Invoker.DoCommandInQueue();
    }
}
