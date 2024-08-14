using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class KeyboardControllActionsInputSystem : IActionsControllInputSystem
{
    private CancellationTokenSource _updateCancellationToken;

    private KeyCode _candleSaveKey;
    private KeyCode _unfreezeCursorKey;

    public event Action candleSaveButtonPressed;
    public event Action unfreezeCursorPressed;
    public event Action unfreezeCursorReleased;

    public KeyboardControllActionsInputSystem(KeyCode candleSaveKey, KeyCode unfreezeCursorKey)
    {
        _updateCancellationToken = new CancellationTokenSource();
        _candleSaveKey = candleSaveKey;
        _unfreezeCursorKey = unfreezeCursorKey;

        UpdateLoop().Forget();
    }

    ~KeyboardControllActionsInputSystem()
    {
        _updateCancellationToken.Cancel();
    }

    private async UniTask UpdateLoop()
    {
        while (true) 
        {
            if (Input.GetKeyDown(_candleSaveKey))
            {
                candleSaveButtonPressed?.Invoke();
            }

            if (Input.GetKey(_unfreezeCursorKey))
            {
                unfreezeCursorPressed?.Invoke();
            }
            else
            {
                unfreezeCursorReleased?.Invoke();
            }

            await UniTask.WaitForSeconds(Time.deltaTime, cancellationToken: _updateCancellationToken.Token);
        }
    }
}