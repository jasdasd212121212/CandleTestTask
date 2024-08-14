using UnityEngine;

public class DesktopLookInputSystem : ILookImputSystem
{
    public Vector2 LookInputVector => new Vector2(Input.GetAxis(InputAxes.MOUSE_X), -Input.GetAxis(InputAxes.MOUSE_Y));
}