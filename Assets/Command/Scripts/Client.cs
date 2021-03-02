using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    //Client has invoker to prepare the command, control the command, and send the command, it is command invoker
    //Client has receiver to receive the command, and then do the actions.
    //Client is like a intermediate point, in the game, it has input handler to deal with commands and ready to send, and it has a receiver for the command and resposive actions.

    // Start is called before the first frame update
    private Invoker m_Invoker = new Invoker();
    private Receiver m_Receiver = new Receiver();

    //command is coupling with receiver. Could I seperate them?
    //for now this method is better for different actors with same action

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Invoker.SaveCommand(new JumpCommand(m_Receiver));
            Debug.Log("Store command from Space.");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            m_Invoker.SaveCommand(new MysticShotCommand(m_Receiver));
            Debug.Log("Store command from Q.");
        }

        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            m_Invoker.DoCommandInQueue();
        }

    }
}
