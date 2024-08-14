public interface IReadOnlyStateMachine
{
    IObservableState GetState<T>() where T : State;
    IObservableState CurrentState { get; }
}