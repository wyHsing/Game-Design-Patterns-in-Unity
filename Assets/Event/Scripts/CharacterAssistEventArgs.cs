using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CharacterAssistEventArgs : EventArgs
{
    private string m_Message;
    private string m_Name;
    private int m_Times;
    public string GetMessage
    {
        get
        {
            return m_Message;
        }
    }

    public string GetName
    {
        get
        {
            return m_Name;
        }
    }

    public int GetTimes
    {
        get
        {
            return m_Times;
        }
    }

    public CharacterAssistEventArgs(string _message, string _name, int _times)
    {
        m_Message = _message;
        m_Name = _name;
        m_Times = _times;
    }
}
