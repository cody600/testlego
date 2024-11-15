namespace LegoInventoryCheck.Data.Interfaces
{
    public interface ISet
    {
        List<IItem> Items { get; set; }
        string Name { get; set; }

        bool CheckItemsMatchOrMore(List<IItem> itemsTarget, bool ingoreColor = false);
    }
}