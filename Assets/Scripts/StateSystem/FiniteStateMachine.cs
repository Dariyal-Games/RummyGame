using UnityEngine;
using System.Collections;

public class FiniteStateMachine<T>
{
    private T owner;
    private FSMState<T> currentState;
    private FSMState<T> globalState;
    private FSMState<T> previousState;

    public void Awake()
    {
        currentState = null;
        globalState = null;
        previousState = null;
    }

    public void Configure(T owner, FSMState<T> initialState)
    {
        this.owner = owner;
        ChangeState(initialState);
    }

    public void Update()
    {
        if (globalState != null) globalState.Update(owner);
        if (currentState != null) currentState.Update(owner);
    }

    public void ChangeState(FSMState<T> nextState)
    {
        previousState = currentState;
        if (currentState != null) currentState.Exit(owner);
        currentState = nextState;
        if (currentState != null) currentState.Enter(owner);
    }

    public void RevertToPreviousState()
    {
        if (previousState != null) ChangeState(previousState);
    }
}
