using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCollector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<KeyCode> keyCodesList = new List<KeyCode>();
    [SerializeField]
    public Dictionary<ActionCommand, KeyCode> keyCodeCommandDic = new Dictionary<ActionCommand, KeyCode>();
    //Link
    public PlayerInputController playerInputController;
  

    //this example is command-oriented, limit commands binding much more keynodes, commands seems little, yet the inner action can be replaced, so it is diverse enough.

    void Start()
    {
        if (playerInputController == null)
        {
            playerInputController = GetComponent<PlayerInputController>();
        }
        if(playerInputController == null)
        {
            playerInputController = new PlayerInputController();
        }

        //not sure where can put
        keyCodeCommandDic.Add(new MoveActionCommand(new Vector3(0, 1, 0)), KeyCode.W);
        keyCodeCommandDic.Add(new MoveActionCommand(new Vector3(0, -1, 0)), KeyCode.S);
        keyCodeCommandDic.Add(new MoveActionCommand(new Vector3(-1, 0, 0)), KeyCode.A);
        keyCodeCommandDic.Add(new MoveActionCommand(new Vector3(1, 0, 0)), KeyCode.D);
        keyCodeCommandDic.Add(new ReplayActionCommand(playerInputController.GetInvoker), KeyCode.R);


    }

    // Update is called once per frame
    void Update()
    {
        //get input data

        if(keyCodeCommandDic.Count != 0)
        {
            foreach(var item in keyCodeCommandDic)
            {
                if (Input.GetKeyDown(item.Value))
                {             
                    if(item.Key.GetAction.GetID != "Replay") playerInputController.GetInvoker.SaveCommand(item.Key);
                    item.Key.Execute();
                }
            }
        }
    }
}
