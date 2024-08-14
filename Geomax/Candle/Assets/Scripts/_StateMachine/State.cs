using System;

public abstract class State : IObservableState
{
    public event Action stateEntered;
    public event Action stateExited;

    public void Enter()
    {
        stateEntered?.Invoke();
        OnEnter();
    }

    public void Exit()
    {
        stateExited?.Invoke();
        OnExit();
    }

    public abstract void OnEnter();
    public virtual void OnExit() { }
}