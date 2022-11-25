namespace MK.Asteroids
{
    public interface IUnitsCreator
    {
        IUnit Create(UnitType type);
    }
}