namespace LegoInventoryCheck.Data.Interfaces
{
    public interface IUser
    {
        List<IItem> Items { get; set; }
        string Name { get; set; }
    }
}