using UnityEngine;
using Zenject;

public class Candle : MonoBehaviour, IEquipment
{
    private FieringCandleState _fiering;
    private ExtingushedCandleState _extingushed;
    private ShieldedCandleState _shielded;

    private StateMachine _stateMachine;

    public IReadOnlyStateMachine StateMachine => _stateMachine;

    [Inject]
    private void Construct()
    {
        _fiering = new FieringCandleState();
        _extingushed = new ExtingushedCandleState();
        _shielded = new ShieldedCandleState();

        _stateMachine = new StateMachine(_fiering, _extingushed, _shielded);
    }

    private void Start()
    {
        TurnOn();
    }

    public void TurnOff()
    {
        if (_stateMachine.CurrentState == _shielded)
        {
            return;
        }

        _stateMachine.ChangeState(_extingushed);
    }

    public void TurnOn()
    {
        _stateMachine.ChangeState(_fiering);
    }

    public void ChangeShielded()
    {
        if (_stateMachine.CurrentState == _extingushed)
        {
            return;
        }

        if (_stateMachine.CurrentState == _shielded)
        {
            TurnOn();
        }
        else
        {
            _stateMachine.ChangeState(_shielded);
        }
    }

    public void Accept(PlayerEquipmentVisitor visitor)
    {
        visitor.Visit(this);
    }
}