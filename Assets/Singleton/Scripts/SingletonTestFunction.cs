using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonTestFunction : MonoBehaviour
{
    // Start is called before the first frame update
    public Text simpleSingletonCounter;
    public Text SOSingletonCounter;
    public Text GenericSOSingletonCounter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        simpleSingletonCounter.text = SimpleSingleton.Instance.btnCounter.ToString();
        SOSingletonCounter.text = SOSingleton.Instance.btnCounter.ToString();
        GenericSOSingletonCounter.text = GenericSOSingletonExample.Instance.btnCounter.ToString();
    }

    public void SimpleSingletonPress()
    {
        SimpleSingleton.Instance.btnCounter++;
    }
    public void SOSingletonPress()
    {
        SOSingleton.Instance.btnCounter++;
        SOSingleton.Instance.Save();
    }

    public void PrefabSingletonPress()
    {
        PrefabSingleton.Instance.AddCounter();
    }

    public void GenericMonoSingletonPress()
    {
        MonoSingletonExample.Instance.AddCounter();
    }
    public void GenericSOSingletonPress()
    {
        GenericSOSingletonExample.Instance.btnCounter++;
        GenericSOSingletonExample.Instance.Save();
    }
}
