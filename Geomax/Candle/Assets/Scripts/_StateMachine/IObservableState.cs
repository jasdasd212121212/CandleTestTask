using System;

public interface IObservableState 
{
    public event Action stateEntered;
    public event Action stateExited;
}