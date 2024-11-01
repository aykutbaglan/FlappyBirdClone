using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

public class StateMachine
{
    private static StateMachine instance;
    //private Menu currentState;
    private State currentState;
    
    //Singleton Instance  Eri�im Noktas� 
    public static StateMachine Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new StateMachine();
            }
            return instance;
        }
    }
    // Constructor'� private yaparak d��ar�dan �rnek olu�turulmas�n� engelleriz
    private StateMachine() { }

    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
            //currentState = newState;
            //currentState.OnExit();
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter();
        }
    }
}
