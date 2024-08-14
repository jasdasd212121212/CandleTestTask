public interface IEquipment
{
    void Accept(PlayerEquipmentVisitor visitor);
}