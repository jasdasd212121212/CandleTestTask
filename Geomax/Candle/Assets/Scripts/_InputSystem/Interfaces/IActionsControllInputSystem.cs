using System;

public interface IActionsControllInputSystem
{
    event Action candleSaveButtonPressed;
    event Action unfreezeCursorPressed;
    event Action unfreezeCursorReleased;
}