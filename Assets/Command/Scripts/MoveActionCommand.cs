using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActionCommand : ActionCommand
{
    // Start is called before the first frame update
    private Vector3 m_Direction;
    
    public MoveActionCommand(Vector3 _vector3)
    {
        m_Direction = _vector3;
        SetAction = new MoveAction();
    }

    public override void Execute()
    {
        Debug.Log("Go with direction " + m_Direction.ToString());
    }
}
