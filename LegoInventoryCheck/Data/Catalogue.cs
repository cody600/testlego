using LegoInventoryCheck.Data.Interfaces;

namespace LegoInventoryCheck.Data
{
    public class Catalogue : ICatalogue
    {
        public Catalogue()
        {
            Sets = [];
        }
        public List<ISet> Sets { get; set; }
    }
}
