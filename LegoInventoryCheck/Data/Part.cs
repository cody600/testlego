using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    public class Part : IPart
    {
        public string Key
        {
            get { return Number.ToString() + Color; }
        }

        public int Number { get; set; }
        public required string Color { get; set; }
    }
}
