namespace LegoInventoryCheck.Data.Interfaces
{
    public interface IItem
    {
        int Count { get; set; }
        IPart Part { get; set; }

        bool ItemPartMatch(IItem i, bool ingoreColor = false);
    }
}