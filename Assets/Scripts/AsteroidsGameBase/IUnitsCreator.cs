namespace MK.AsteroidsGame
{
    public interface IUnitsCreator
    {
        IUnit Create(UnitType type);
    }
}