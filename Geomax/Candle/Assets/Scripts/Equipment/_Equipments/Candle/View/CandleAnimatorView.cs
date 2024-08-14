using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CandleAnimatorView : MonoBehaviour
{
    [SerializeField] private Candle _model;
    [SerializeField] private string _shieldingAnimatorKey = "Shielding";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        IObservableState shieldingState = _model.StateMachine.GetState<ShieldedCandleState>();

        shieldingState.stateEntered += EnableShielding;
        shieldingState.stateExited += DisableShielding;
    }

    private void OnDestroy()
    {
        IObservableState shieldingState = _model.StateMachine.GetState<ShieldedCandleState>();

        shieldingState.stateEntered -= EnableShielding;
        shieldingState.stateExited -= DisableShielding;
    }

    private void EnableShielding()
    {
        _animator.SetBool(_shieldingAnimatorKey, true);
    }

    private void DisableShielding()
    {
        _animator.SetBool(_shieldingAnimatorKey, false);
    }
}