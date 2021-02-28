using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GenericSOSingleton<T> : ScriptableObject where T : ScriptableObject
{
    protected static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if(m_Instance != null)
            {
                return m_Instance;
            }

            var singletonName = typeof(T).Name;

            var assets = Resources.LoadAll<T>("");
            if(assets.Length > 1)
            {
                Debug.LogError("Found Multiples" + singletonName + "in Resources");
            }
            else if(assets.Length == 0)
            {
                m_Instance = ScriptableObject.CreateInstance<T>();
            }
            else
            {
                m_Instance = assets[0];
            }
            return m_Instance;

        }
    }
}
