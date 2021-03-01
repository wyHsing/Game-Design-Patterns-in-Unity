using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character
{
    //Case 1: Custom Delegation and Event
    public delegate void CharacterKill(ECharacter eCharacter);
    public event CharacterKill CharacterKillHandler;
    //Case 2: EventHandler from System, using no Args
    public event EventHandler CharacterDieHandler;
    //Case 3: EventHandler from System, using custom EventArgs
    public event EventHandler<CharacterAssistEventArgs> CharacterAssistHandler;

    public ECharacter GetECharacter
    {
        get
        {
            return m_ECharacter;
        }
    }
    protected ECharacter m_ECharacter;
    public virtual void Kill()
    {
        CharacterKillHandler?.Invoke(m_ECharacter); //if(CharacterKillHnadler != null) CharacterKillHandler(_eCharacter);
    }

    public virtual void Die()
    {
        CharacterDieHandler?.Invoke(this, EventArgs.Empty);
    }
    
    public virtual void Assist()
    {
        CharacterAssistEventArgs curAssistArgs = new CharacterAssistEventArgs("Assistance is the symbol of a good teammate.", m_ECharacter.ToString(), 1);
        CharacterAssistHandler?.Invoke(this, curAssistArgs);
    }

}
public enum ECharacter { Ezreal, Vi, Zyra }
