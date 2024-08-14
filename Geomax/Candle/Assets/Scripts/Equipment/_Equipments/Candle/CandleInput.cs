using UnityEngine;
using Zenject;

[RequireComponent(typeof(Candle))]
public class CandleInput : MonoBehaviour
{
    [Inject] private IActionsControllInputSystem _input;

    private Candle _candle;

    private void Awake()
    {
        _candle = GetComponent<Candle>();   

        _input.candleSaveButtonPressed += ChangeShielded;
    }

    private void OnDestroy()
    {
        _input.candleSaveButtonPressed -= ChangeShielded;
    }

    private void ChangeShielded()
    {
        _candle.ChangeShielded();
    }
}