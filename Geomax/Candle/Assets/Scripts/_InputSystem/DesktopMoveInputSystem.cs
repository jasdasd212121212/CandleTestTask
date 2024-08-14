using UnityEngine;

public class DesktopMoveInputSystem : IMoveInputSystem
{
    public Vector2 InputVector => new Vector2(Input.GetAxisRaw(InputAxes.HORIZONTAL), Input.GetAxisRaw(InputAxes.VERTICAL));
}