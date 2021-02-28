using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    // Start is called before the first frame update
    public delegate void CharacterKill(ECharacter eCharacter);
    public event CharacterKill CharacterKillHandler;

    public ECharacter GetECharacter
    {
        get
        {
            return m_eCharacter;
        }
    }
    protected ECharacter m_eCharacter;
    public virtual void Kill()
    {
        CharacterKillHandler?.Invoke(m_eCharacter); //if(CharacterKillHnadler != null) CharacterKillHandler(_eCharacter);
    }

    

}
public enum ECharacter { Ezreal, Vi, Zyra }
