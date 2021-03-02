using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraspingRootsCommand : Command
{
    private Receiver receiver;

    public GraspingRootsCommand(Receiver _receiver)
    {
        receiver = _receiver;
    }
    public override void Execute()
    {
        base.Execute();
        receiver.Root();

    }


}
