 using UnityEngine;

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
    /// <summary>
    /// Parametre olarak bir state referansý vermen gerekir
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
    /// <summary>
    /// Bir sonraki State geçer. Dizi eleman sayýsýný geçtiðinde hata atar
    /// </summary>
    public void TransitionToNextState()
    {
        if (stateNum < states.Length)
        {
            ChangeState(states[stateNum]);
            stateNum++;
        }
        else
        {
            //Debug.Log("State sýnýr aþýldý.");
        }
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