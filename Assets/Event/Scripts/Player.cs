using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<Character> MyCharacterList = new List<Character>();
    public Dictionary<ECharacter, int> MyCharacterKillRecords = new Dictionary<ECharacter, int>();
    
    
    void Start()
    {
        MyCharacterList.Add(new Zyra());
        MyCharacterList.Add(new Ezreal());
       
        MyCharacterList.Sort((x, y) => x.GetECharacter.CompareTo(y.GetECharacter));// test sort func in passing.

        foreach (var item in MyCharacterList)
        {
            Debug.Log("This is " + item.GetECharacter.ToString());
            MyCharacterKillRecords.Add(item.GetECharacter, 0);
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
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //add Zyra
            Debug.Log(MyCharacterList[1].GetECharacter.ToString() + " kill observer added.");
            MyCharacterList[1].CharacterKillHandler -= AddKill;
            MyCharacterList[1].CharacterKillHandler += AddKill;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //Remove all
            Debug.Log("Remove all.");
            MyCharacterList[0].CharacterKillHandler -= AddKill;
            MyCharacterList[1].CharacterKillHandler -= AddKill;
        }

        else if (Input.GetKeyDown(KeyCode.K))
        {
            foreach(var item in MyCharacterList)
            {
                item.Kill();
            }
        }
    }

    public void AddKill(ECharacter _eCharacter)
    {
        MyCharacterKillRecords[_eCharacter]++;
        Debug.Log(_eCharacter.ToString() + " kill value: " + MyCharacterKillRecords[_eCharacter].ToString());
    }
}
