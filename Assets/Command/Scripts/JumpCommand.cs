using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    private Receiver receiver;

    public JumpCommand(Receiver _receiver)
    {
        receiver = _receiver;
    }
    public override void Execute()
    {
        base.Execute();
        receiver.Jump();

    }
}
