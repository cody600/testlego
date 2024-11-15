using LegoInventoryCheck.Data;
using LegoInventoryCheck.Data.Interfaces;
using LegoInventoryCheck.Interfaces;

namespace LegoInventoryCheck.Services
{
    public class InventoryCheck(IExampleDataProvider provider) : IInventoryCheck
    {

        private readonly IExampleDataProvider dataProvider = provider;

        /// <summary>
        /// Given the specific user name to check against the Lego Catalogue  to see what sets of lego that the user can build 
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="ignoreColor">require color match or not default is false</param>
        /// <returns></returns>
        public List<ISet> CheckUserCatalogueCapability(string userName, bool ignoreColor)
        {
            var u = dataProvider.GetUserData(userName);
            Catalogue c = dataProvider.GetLegoCatalogue();

            List<ISet> r = new();

            foreach (var set in c.Sets)
            {
                if (set.CheckItemsMatchOrMore(u.Items, ignoreColor))
                    r.Add((Set)set);
            }

            return r;
        }

        /// <summary>
        /// Look for any other users to support the specifice user name to finish the specific set construction. Per User Base not Combined users with partial match.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="setName"></param>
        /// <param name="ignoreColor"></param>
        /// <returns></returns>
        public List<IUser> CheckUserSetHelpers(string userName, string setName, bool ignoreColor)
        {
            List<IUser> r = new();
            IUser currentU = dataProvider.GetUserData(userName);
            ICatalogue c = dataProvider.GetLegoCatalogue();
            var set = c.Sets.Find(s => s.Name == setName);

            if (set == null)
                throw new Exception("Set " + setName + " not found");

            List<IItem> missItems = new();

            //Find the missing items for target user on specific set 
            foreach (var s in set.Items)
            {
                var partMatchItem = currentU.Items.Find(i => s.ItemPartMatch( i, ignoreColor));
                if (partMatchItem != null && (partMatchItem.Count >= s.Count))
                    continue;   // Both Count and Part is good to go

                if (partMatchItem == null) // Not found
                {
                    missItems.Add(s);
                }
                else  // Partial found
                {
                    missItems.Add(new Item { Count = s.Count - partMatchItem.Count, Part = partMatchItem.Part });
                }
            }

            // Find users that can help for the missing items
            foreach (var u in dataProvider.GetUsers())
            {
                if (u.Name != userName) // exclude self
                {
                    if (missItems.All(i => u.Items.Find(ui => ui.ItemPartMatch(i, ignoreColor) && ui.Count >= i.Count) != null ))
                    {
                        r.Add(u);
                    }
                }
            }

            return r;
        }

        /// <summary>
        // The user megabuilder99 is interested in creating a new custom build but they want to make sure other people could complete it with their current inventories.
        // What is the largest collection of pieces they should restrict themselves to
        // if they want to ensure that at least 50% of other users could complete the build?
        /// </summary>
        /// <param name="numerator"> Percentage to match. Example 50 is 50%</param>
        public List<IItem> CustomItemsWithTargetUserRate(int numeratorPercent)
        {
            var result = new List<IItem>(); // result
            Dictionary<string, List<string>> partKeyUserListDict = new Dictionary<string, List<string>>(); // Item's part key to ownership list
            Dictionary<string, IPart> partKeyToPartDict = new Dictionary<string, IPart>(); //Lookup table for part key to part


            //1. Get the threshold user match count.
            #region 

            var users = dataProvider.GetUsers();
            var threshold = Math.Floor((double)users.Count * numeratorPercent / 100); // Even is half, odd will be integer part of half number. Little bit small. That is assumption. 

            #endregion

            //2. Walk through all User Items part by part. Collect each item's Part with user ownership list. Collect Item For users and filter out only items has >= threshold
            #region 

            // Walk User list to collect all the part info
            foreach (var u in users)
            {
                foreach (var i in u.Items)
                {
                    if (!partKeyUserListDict.ContainsKey(i.Part.Key))
                    {
                        partKeyUserListDict.Add(i.Part.Key, new List<string>());
                    }

                    partKeyUserListDict[i.Part.Key].Add(u.Name);
                    partKeyToPartDict[i.Part.Key] = i.Part;
                }
            }

            // Filter out ownership count less than theshold
            List<string> deleteKey = new();
            foreach (var k in partKeyUserListDict.Keys)
            {
                if (partKeyUserListDict[k].Count < threshold)
                    deleteKey.Add(k);
            }

            // Remove the keys from the deletekey
            foreach (var d in deleteKey)
            {
                partKeyUserListDict.Remove(d);
                partKeyToPartDict.Remove(d);
            }

            // ToDO: Need to limit the combine for mutiple parts scenario.
            #region
            // Now the partNumUserListDict only has user count match threshold. Need to collect same threshold number users for all the parts
            //IEnumerable<string> tempUsers = new List<string>();
            //foreach (var v in partKeyUserListDict.Values)
            //{
            //    if (tempUsers.Count() == 0)
            //        tempUsers = v;
            //    else 
            //        tempUsers = tempUsers.Intersect(v);
            //}              

            //Reconcile the partNumUserListDict users for no need.
            //foreach (var kx in partKeyUserListDict.Keys)
            //{
            //    partKeyUserListDict[kx] = partKeyUserListDict[kx].TakeWhile(s => tempUsers.Contains(s)).ToList();
            //}

            // partKeyUserListDict = (Dictionary<string, List<string>>)partKeyUserListDict.TakeWhile(d => d.Value.Count >= threshold);
            #endregion

            #endregion

            //3. From the previous steps items ownership collection filter out part count to  >=  threshold for per part                                   
            #region 
            var minimumItemCount = 0;
            foreach (var ky in partKeyUserListDict.Keys)
            {
                foreach (var u in partKeyUserListDict[ky])
                {
                    var user = users.Where(i => i.Name == u).First();
                    var item = user.Items.Where(i => i.Part.Key == ky).First();
                    if (minimumItemCount == 0)
                        minimumItemCount = item.Count;
                    else
                        minimumItemCount = Math.Min(minimumItemCount, item.Count);
                }
                result.Add(new Item { Part = partKeyToPartDict[ky], Count = minimumItemCount });
            }
            #endregion                            

            return result;
        }
    }
}
