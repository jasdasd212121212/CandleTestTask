using Zenject;

public class PlayerEquipmentVisitorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerEquipmentVisitor>().FromInstance(new PlayerEquipmentVisitor()).AsSingle().NonLazy();
    }
}