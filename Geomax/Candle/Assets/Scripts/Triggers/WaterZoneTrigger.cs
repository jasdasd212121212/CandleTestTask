using UnityEngine;
using Zenject;

public class WaterZoneTrigger : BaseBoxTrigger
{
    [Inject] private PlayerEquipmentVisitor _visitor;

    protected override void OnEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerEquipment player))
        {
            player.CurrentEquipment.Accept(_visitor);
        }
    }
}