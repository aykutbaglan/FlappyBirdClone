using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    //private static StateMachine instance;
    //private Menu currentState;

    ////Singleton Instance  Eri�im Noktas� 
    //public static StateMachine Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new StateMachine();
    //        }
    //        return instance;
    //    }
    //}
    // Constructor'� private yaparak d��ar�dan �rnek olu�turulmas�n� engelleriz

    public State currentState;
    [SerializeField] private State[] states;
    private int stateNum;

    private void Start()
    {
        if (PlayerPrefs.GetInt("isGameRestarted", 1) == 0)
        {
            TransitionToNextState();
        }
        else
        {
            TransitionToSpecificState(1);
        }
    }
    /// <summary>
    /// Parametre olarak bir state referans� vermen gerekir
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {

        if (currentState != null)
        {
            currentState.OnExit();
            //currentState = newState;
            //currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
    /// <summary>
    /// Bir sonraki State ge�er. Dizi eleman say�s�n� ge�ti�inde hata atar
    /// </summary>
    public void TransitionToNextState()
    {
        ChangeState(states[stateNum]);
        stateNum++;

    }
    public void TransitionToSpecificState(int stateId)
    {
        ChangeState(states[stateId]);
        stateNum = stateId +1;
    }
    public void CloseAllState()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].OnExit();
        }
    }
}
