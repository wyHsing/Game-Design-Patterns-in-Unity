using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabSingleton : MonoBehaviour
{
    private static PrefabSingleton m_Instance;

    //custom test
    public int btnCounter = 0;
    public static PrefabSingleton Instance
    {
        get
        {
            if(m_Instance != null)
            {
                Debug.Log("Case1: Return loaded singleton.");
                return m_Instance;
            }

            m_Instance = FindObjectOfType<PrefabSingleton>();
            if(m_Instance != null)
            {
                Debug.Log("Case2: Found the active object in memory.");
                return m_Instance;
            }

            //Case 3
            Debug.Log("Case3: Create from resources");
            CreateDefault();
            return m_Instance;
        }
    }
    public static void CreateDefault()
    {
        PrefabSingleton prefab = Resources.Load<PrefabSingleton>("Prefab/PrefabSingleton");
        m_Instance = Instantiate(prefab);
        m_Instance.gameObject.name = "PrefabSingleton";
    }


    private void Awake()
    {
        Debug.Log("PrefabSingleton Awake().");
        if(Instance != this)
        {
            Debug.Log("Need to destroy the extra object.");
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);// make it stay when scene changes.

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PrefabSingleton Start().");
    }


    #region Singleton Test
    public Text counterText = null;

    public void AddCounter()
    {
        btnCounter++;
        UpdateUI();
    }
    private void SetupCounterText()
    {
        GameObject obj = GameObject.Find("PrefabSingletonCounterText");
        if(obj == null)
        {
            return;
        }
        counterText = obj.GetComponent<Text>();
    }
    public void UpdateUI()
    {
        if(counterText == null)
        {
            SetupCounterText();
        }
        if(counterText != null)
        {
            counterText.text = btnCounter.ToString();
        }
    }
    #endregion
}
