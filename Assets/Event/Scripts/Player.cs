using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    public List<Character> MyCharacterList = new List<Character>();
    public Dictionary<ECharacter, int> MyCharacterKillRecords = new Dictionary<ECharacter, int>();
    public Dictionary<ECharacter, int> MyCharacterDieRecords = new Dictionary<ECharacter, int>();
    public Dictionary<ECharacter, int> MyCharacterAssistRecords = new Dictionary<ECharacter, int>();

    void Start()
    {
        MyCharacterList.Add(new Zyra());
        MyCharacterList.Add(new Ezreal());

        MyCharacterList.Sort((x, y) => x.GetECharacter.CompareTo(y.GetECharacter));// Test sort function in passing.

        foreach (var item in MyCharacterList)
        {
            Debug.Log("This is " + item.GetECharacter.ToString());
            MyCharacterKillRecords.Add(item.GetECharacter, 0);
            MyCharacterDieRecords.Add(item.GetECharacter, 0);
            MyCharacterAssistRecords.Add(item.GetECharacter, 0);
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //add Ezreal
            Debug.Log(MyCharacterList[0].GetECharacter.ToString() + " kill observer added.");
            MyCharacterList[0].CharacterKillHandler -= AddKill;
            MyCharacterList[0].CharacterKillHandler += AddKill;

            Debug.Log(MyCharacterList[0].GetECharacter.ToString() + " die observer added.");
            MyCharacterList[0].CharacterDieHandler -= AddDie;
            MyCharacterList[0].CharacterDieHandler += AddDie;

            Debug.Log(MyCharacterList[0].GetECharacter.ToString() + " assist observer added.");
            MyCharacterList[0].CharacterAssistHandler -= AddAssist;
            MyCharacterList[0].CharacterAssistHandler += AddAssist;

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //add Zyra
            Debug.Log(MyCharacterList[1].GetECharacter.ToString() + " kill observer added.");
            MyCharacterList[1].CharacterKillHandler -= AddKill;
            MyCharacterList[1].CharacterKillHandler += AddKill;

            Debug.Log(MyCharacterList[0].GetECharacter.ToString() + " die observer added.");
            MyCharacterList[1].CharacterDieHandler -= AddDie;
            MyCharacterList[1].CharacterDieHandler += AddDie;

            Debug.Log(MyCharacterList[1].GetECharacter.ToString() + " assist observer added.");
            MyCharacterList[1].CharacterAssistHandler -= AddAssist;
            MyCharacterList[1].CharacterAssistHandler += AddAssist;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //Remove all
            Debug.Log("Remove all.");
            MyCharacterList[0].CharacterKillHandler -= AddKill;
            MyCharacterList[1].CharacterKillHandler -= AddKill;

            MyCharacterList[0].CharacterDieHandler -= AddDie;
            MyCharacterList[1].CharacterDieHandler -= AddDie;

            MyCharacterList[0].CharacterAssistHandler -= AddAssist;
            MyCharacterList[1].CharacterAssistHandler -= AddAssist;
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (var item in MyCharacterList)
            {
                item.Die();
            }
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in MyCharacterList)
            {
                item.Assist();
            }
        }

        else if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (var item in MyCharacterList)
            {
                item.Kill();
            }
        }
    }

    public void AddKill(ECharacter _eCharacter)
    {
        MyCharacterKillRecords[_eCharacter]++;
        Debug.Log(_eCharacter.ToString() + " kill times: " + MyCharacterKillRecords[_eCharacter].ToString());
    }

    public void AddDie(object _sender, EventArgs _eventArgs)
    {


        Character character = (Character)_sender;
        if (character != null)
        {
            MyCharacterDieRecords[character.GetECharacter]++;
            Debug.Log(character.GetECharacter.ToString() + " Die times: " + MyCharacterDieRecords[character.GetECharacter].ToString());
        }


    }

    public void AddAssist(object _sender, EventArgs _eventArgs)
    {
        
        CharacterAssistEventArgs assistArgs = (CharacterAssistEventArgs)_eventArgs;
        if (assistArgs == null) return;

        Character character = (Character)_sender;
        if (character != null)
        {
            if (Enum.TryParse(assistArgs.GetName, out ECharacter result))// if u want to discard result, use _
            {
                ECharacter parsedEnum = result;
                MyCharacterAssistRecords[parsedEnum] += assistArgs.GetTimes;
                Debug.Log(assistArgs.GetName + " Assist times: " + MyCharacterAssistRecords[parsedEnum].ToString());
            }
            else
            {
                MyCharacterAssistRecords[character.GetECharacter] += assistArgs.GetTimes;
                Debug.Log(assistArgs.GetName + " Assist times: " + MyCharacterAssistRecords[character.GetECharacter].ToString());
            }

            Debug.Log(assistArgs.GetMessage);
        }
    }
}
