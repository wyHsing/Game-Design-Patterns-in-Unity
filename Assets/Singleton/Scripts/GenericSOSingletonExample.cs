using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myHelper;

public class GenericSOSingletonExample : GenericSOSingleton<GenericSOSingletonExample>
{
    //custom test
    public int btnCounter = 0;
    public string filePath = "/GenericSOCounter.sav";

    private void OnEnable()
    {
        Load();
    }

    public void Save()
    {
        string path = Application.persistentDataPath + filePath;
        FileHelper.WriteFile(path, btnCounter.ToString());
    }

    public void Load()
    {
        string path = Application.persistentDataPath + filePath;
        string value = FileHelper.ReadFile(path);

        if(value == null || value == "")
        {
            btnCounter = 0;
        }
        else
        {
            try
            {
                btnCounter = int.Parse(value);
            }
            catch(System.Exception e)
            {
                Debug.LogError("Can't Parse to int.");
                btnCounter = 0;
            } 
        }
    }
}
