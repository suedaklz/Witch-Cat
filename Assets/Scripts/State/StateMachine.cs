using UnityEngine;

public class StateMachine
{
    public IState state;

    public void Set(IState newState, bool forceReset = false)
    {
        if (state != newState || forceReset)
        {
            state?.OnExit();
            state = newState;
            Debug.Log("State Bug Test---------- Monobehahiovur : " + state.characterManager + " , new state : " + newState);
            state.Initialise();
            state.OnEnter();
        }
    }
}
