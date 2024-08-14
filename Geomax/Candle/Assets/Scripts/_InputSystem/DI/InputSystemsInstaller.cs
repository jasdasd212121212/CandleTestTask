using UnityEngine;
using Zenject;

public class InputSystemsInstaller : MonoInstaller
{
    [SerializeField] private KeyCode _candleButtonSaveKey = KeyCode.E;
    [SerializeField] private KeyCode _unfreezeCursorKey = KeyCode.LeftControl;

    public override void InstallBindings()
    {
        Container.Bind<IMoveInputSystem>().FromInstance(new DesktopMoveInputSystem()).AsSingle().NonLazy();
        Container.Bind<ILookImputSystem>().FromInstance(new DesktopLookInputSystem()).AsSingle().NonLazy();
        Container.Bind<IActionsControllInputSystem>().FromInstance(new KeyboardControllActionsInputSystem(_candleButtonSaveKey, _unfreezeCursorKey)).AsSingle().NonLazy();
    }
}