using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoSingletonExample : GenericMonoSingleton<MonoSingletonExample>
{
    protected override string GetSingletonName()
    {
        return "MonoSingletonExample";
    }

    protected override bool ShouldDestroyOnLoad()
    {
        return base.ShouldDestroyOnLoad();
    }

    protected override void DidAwake()
    {
        base.DidAwake();
        Debug.Log("MonoSingletonExample Awake!!!");
    }

    //custom test
    public int btnCounter = 0;


    #region Singleton Test
    public Text counterText = null;

    public void AddCounter()
    {
        btnCounter++;
        UpdateUI();
    }
    private void SetupCounterText()
    {
        GameObject obj = GameObject.Find("MonoSingletonExampleCounterText");
        if (obj == null)
        {
            return;
        }
        counterText = obj.GetComponent<Text>();
    }
    public void UpdateUI()
    {
        if (counterText == null)
        {
            SetupCounterText();
        }
        if (counterText != null)
        {
            counterText.text = btnCounter.ToString();
        }
    }
    #endregion
}
