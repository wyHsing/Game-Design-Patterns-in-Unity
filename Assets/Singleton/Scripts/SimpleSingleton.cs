using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingleton
{
    //test: can i make it null at first and then check if null to give it instance?
    static readonly SimpleSingleton m_Instance = new SimpleSingleton();
    
    //custom test
    public int btnCounter = 0;
    public static SimpleSingleton Instance
    {
        get
        { 
            return m_Instance; 
        }
    }

    private SimpleSingleton()
    {
        Debug.Log("Construct the SimpleSingleton.");
    }

}
