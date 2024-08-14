using UnityEngine;
using Zenject;

public class CursorStateMachine : MonoBehaviour
{
    [Inject] private IActionsControllInputSystem _input;

    private CursorFreezedState _freezed;
    private CursorUnfreezedState _unfreezed;

    private StateMachine _stateMachine;

    private void Start()
    {
        _freezed = new CursorFreezedState();
        _unfreezed = new CursorUnfreezedState();

        _stateMachine = new StateMachine(_freezed, _unfreezed);

        _input.unfreezeCursorPressed += OnPressed;
        _input.unfreezeCursorReleased += OnReleased;
    }

    private void OnDestroy()
    {
        _input.unfreezeCursorPressed -= OnPressed;
        _input.unfreezeCursorReleased -= OnReleased;
    }

    private void OnPressed()
    {
        SetState(true);
    }

    private void OnReleased()
    {
        SetState(false);
    }

    private void SetState(bool state)
    {
        if (state == true)
        {
            _stateMachine.ChangeState(_unfreezed);
        }
        else
        {
            _stateMachine.ChangeState(_freezed);
        }
    }
}