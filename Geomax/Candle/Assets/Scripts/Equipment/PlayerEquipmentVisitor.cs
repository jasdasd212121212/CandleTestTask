public class PlayerEquipmentVisitor
{
    public void Visit(Candle candle)
    {
        candle.TurnOff();
    }
}