using UnityEngine;

public class CandleEffectsView : MonoBehaviour
{
    [SerializeField] private Candle _model;

    [Space]

    [SerializeField] private Light _candleLight;
    [SerializeField] private ParticleSystem _fireParticles;

    private void Awake()
    {
        _model.StateMachine.GetState<FieringCandleState>().stateEntered += EnableEffects;
        _model.StateMachine.GetState<ExtingushedCandleState>().stateEntered += DisbaleDisable;
    }

    private void OnDestroy()
    {
        _model.StateMachine.GetState<FieringCandleState>().stateEntered -= EnableEffects;
        _model.StateMachine.GetState<ExtingushedCandleState>().stateEntered -= DisbaleDisable;
    }

    private void EnableEffects()
    {
        _candleLight.enabled = true;
        _fireParticles.Play();
    }

    private void DisbaleDisable()
    {
        _candleLight.enabled = false;
        _fireParticles.Stop();
    }
}