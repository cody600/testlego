using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    public class Item : IItem
    {
        public required IPart Part { get; set; }
        public int Count { get; set; }
        public bool ItemPartMatch(IItem i, bool ingoreColor = false)
        {
            return (i.Part.Number == Part.Number) && (ingoreColor || i.Part.Color == Part.Color);
        }
    }
}
