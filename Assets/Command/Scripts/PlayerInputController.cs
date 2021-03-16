using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Invoker m_Invoker = new Invoker();
    public Invoker GetInvoker { get { return m_Invoker; } }
    // Start is called before the first frame update
    void Awake()
    {
        //m_Invoker = new Invoker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
