using LegoInventoryCheck.Data;
using LegoInventoryCheck.Data.Interfaces;
using System.Collections.Generic;


namespace LegoInventoryCheck.Interfaces
{
    public interface IInventoryCheck
    {
        /// <summary>
        /// Given the specific user name to check against the Lego Catalogue  to see what sets of lego that the user can build 
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="ignoreColor">require color match or not default is false</param>
        /// <returns></returns>
        List<ISet> CheckUserCatalogueCapability(string userName, bool ignoreColor);

        /// <summary>
        /// Look for any other users to support the specifice user name to finish the specific set construction. Per User Base not Combined users with partial match.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="setName"></param>
        /// <param name="ignoreColor"></param>
        /// <returns></returns>
        List<IUser> CheckUserSetHelpers(string userName, string setName, bool ignoreColor);

        /// <summary>
        /// The user megabuilder99 is interested in creating a new custom build but they want to make sure other people could complete it with their current inventories.
        /// What is the largest collection of pieces they should restrict themselves to
        /// if they want to ensure that at least 50% of other users could complete the build?
        /// </summary>
        /// <param name="numerator"> Percentage to match. Exmaple 50 is 50%</param>
         List<IItem> CustomItemsWithTargetUserRate(int numeratorPercent);
    }
}
