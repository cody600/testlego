using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    public class User : IUser
    {
        public User()
        {
            Items = [];
        }
        public required String Name { get; set; }
        public List<IItem> Items { get; set; }
    }
}
