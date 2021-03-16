using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    private string m_ID;
    public string GetID
    {
        get
        {
            return m_ID;
        }

    }

    public string SetID
    {
        set
        {
            m_ID = value;
        }
    }


    public Action()
    {
        m_ID = "Action";
    }

    public virtual void DoAction()
    {

    }

    public virtual void SetAction()
    {

    }
}
