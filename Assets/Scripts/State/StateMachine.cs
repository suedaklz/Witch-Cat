using UnityEngine;

public class StateMachine
{
    public State state;

    public void Set(State newState, bool forceReset = false)
    {
        if (state != newState || forceReset)
        {
            state?.OnExit();
            state = newState;
            state.Initialise();
            state.OnEnter();
        }
    }
}
