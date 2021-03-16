using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCommand
{
    private object m_CommandProvider;
    private object m_CommandOperator;
    private Action m_Action;
    public Action GetAction { get { return m_Action; } }
    public Action SetAction { set { m_Action = value; } }
    public virtual void Execute()
    {
        m_Action.DoAction();
    }

    public virtual void ChangeAction(Action _action)
    {
        m_Action = _action;
        
    }
}
