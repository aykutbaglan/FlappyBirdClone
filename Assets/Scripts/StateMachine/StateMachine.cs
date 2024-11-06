using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    //private static StateMachine instance;
    //private Menu currentState;

    ////Singleton Instance  Eriþim Noktasý 
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
    // Constructor'ý private yaparak dýþarýdan örnek oluþturulmasýný engelleriz

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


}
