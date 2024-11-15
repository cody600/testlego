namespace LegoInventoryCheck.Data.Interfaces
{
    public interface IPart
    {
        string Color { get; set; }
        string Key { get; }
        int Number { get; set; }
    }
}