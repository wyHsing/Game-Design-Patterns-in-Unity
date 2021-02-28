using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericMonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;
    public static T Instance
    {
        get
        {
            //Case 1
            if(m_Instance != null)
            {
                return m_Instance;
            }
            //Case 2
            m_Instance = FindObjectOfType<T>();
            if(m_Instance != null)
            {
                return m_Instance;
            }
            //Case 3
            CreateDefault();

            return m_Instance;
        }
    }

    static void CreateDefault()
    {
        GameObject singletonObject = new GameObject("Singleton");
        m_Instance = singletonObject.AddComponent<T>();
    }

    public void UpdateSingletonName()
    {
        gameObject.name = GetSingletonName();
    }

    //Implementation
    protected abstract string GetSingletonName();
    protected virtual bool ShouldDestroyOnLoad()
    {
        return false;
    }
    protected virtual void DidAwake() {
    }

    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        UpdateSingletonName();
        if(ShouldDestroyOnLoad() == false)
        {
            DontDestroyOnLoad(gameObject);
        }
        DidAwake();
    }



}
