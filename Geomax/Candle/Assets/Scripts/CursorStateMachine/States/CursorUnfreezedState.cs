using UnityEngine;

public class CursorUnfreezedState : State
{
    public override void OnEnter()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}