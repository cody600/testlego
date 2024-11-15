namespace LegoInventoryCheck.Data.Interfaces
{
    public interface IExampleDataProvider
    {
        Catalogue GetLegoCatalogue();
        IUser GetUserData(string userName);
        List<IUser> GetUsers();
    }
}