using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SOSingleton : ScriptableObject
{
    //Scriptable object advantages: can use I/O, earlier than MonoBehaivour
    //ref: https://kendevlog.wordpress.com/2018/08/14/unity%E5%AD%B8%E7%BF%92%E7%AD%86%E8%A8%98%EF%BC%9A%E5%A6%82%E4%BD%95%E5%AF%A6%E7%8F%BEsingleton/

    //custom test
    public string filePath = "/SOSingleton.sav";
    public int btnCounter = 0;

    protected static SOSingleton m_Instance = null;
    public static SOSingleton Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = ScriptableObject.CreateInstance<SOSingleton>();
                m_Instance.hideFlags = HideFlags.HideAndDontSave;
                //not visable to the user and not save;
            }
            return m_Instance;
        }
    }

    public SOSingleton()
    {
        //can't load data from persistence path at constructor, go to onEnable
    }

    private void OnEnable()
    {
        //custom
        Load();
    }

    public void Save()
    {
        string path = Application.persistentDataPath + filePath;

        StreamWriter writer = new StreamWriter(path);

        writer.Write(btnCounter.ToString());
        writer.Close();
    }

    public void Load()
    {
        string path = Application.persistentDataPath + filePath;
        //Debug.Log("Path: " + path);
        //file I/O
        string counterValue;
        try
        {
            StreamReader reader = new StreamReader(path);
            string result = reader.ReadToEnd();
            reader.Close();
            counterValue = result;
        }
        catch (System.Exception e)
        {
            Debug.Log("I/O exception: " + e);
            counterValue = null;
        }

        if(counterValue == null || counterValue == "")
        {
            btnCounter = 0;
        }
        else
        {
            try
            {
                btnCounter = int.Parse(counterValue);
            }
            catch (FormatException e)
            {
                Debug.Log(e.Message);
                btnCounter = 0;
            }
        }
    }
}
