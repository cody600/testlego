using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    public class Set : ISet
    {
        public Set()
        {
            Items = [];
        }
        public required string Name { get; set; }
        public List<IItem> Items { get; set; }

        /// <summary>
        /// Check Item equal or not for given specific target item with color match option
        /// </summary>
        /// <param name="itemsTarget"></param>
        /// <param name="ingoreColor">default is false</param>
        /// <returns></returns>
        public bool CheckItemsMatchOrMore(List<IItem> itemsTarget, bool ingoreColor = false)
        {
            return Items.All(sourceItem => itemsTarget.Any(targetItem =>
            targetItem.Count >= sourceItem.Count &&  // number of parts matches or greater 
            targetItem.Part.Number == sourceItem.Part.Number && // Part Number matches
            (ingoreColor || targetItem.Part.Color == sourceItem.Part.Color)
            ));
        }
    }
}
