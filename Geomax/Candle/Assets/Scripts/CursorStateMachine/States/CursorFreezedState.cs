using UnityEngine;

public class CursorFreezedState : State
{
    public override void OnEnter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}