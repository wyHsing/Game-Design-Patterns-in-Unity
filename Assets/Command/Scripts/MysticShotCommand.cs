using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysticShotCommand : Command
{
    private Receiver receiver;

    public MysticShotCommand(Receiver _receiver)
    {
        receiver = _receiver;
    }
    public override void Execute()
    {
        base.Execute();
        receiver.Shoot();

    }
}
