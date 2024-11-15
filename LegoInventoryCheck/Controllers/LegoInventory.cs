using LegoInventoryCheck.Data.Interfaces;
using LegoInventoryCheck.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LegoInventoryCheck.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LegoInventory(IInventoryCheck inventoryCheckService, ILogger<LegoInventory> log) : ControllerBase
    {
        private readonly IInventoryCheck _inventoryCheck = inventoryCheckService;
        private readonly ILogger _logger = log;

        [HttpGet(Name = "GetUserCatalogueCapability")]
        public IEnumerable<ISet> GetUserCatalogueCapability(string userName, bool ignoreColor)
        {
            _logger.LogInformation("GetUserCatalogueCapability called at {DT}", DateTime.UtcNow.ToLongTimeString());
            return _inventoryCheck.CheckUserCatalogueCapability(userName, ignoreColor);
        }

        [HttpGet(Name = "CheckUserSetHelpers")]
        public IEnumerable<IUser> CheckUserSetHelpers(string userName, string userSet, bool ignoreColor)
        {
            _logger.LogInformation("CheckUserSetHelpers called at {DT}", DateTime.UtcNow.ToLongTimeString());
            return _inventoryCheck.CheckUserSetHelpers(userName, userSet, ignoreColor);
        }

        [HttpGet(Name = "CustomItemsWithTargetUserRate")]
        public IEnumerable<IItem> CustomItemsWithTargetUserRate(int rate)
        {
            _logger.LogInformation("CustomItemsWithTargetUserRate called at {DT}", DateTime.UtcNow.ToLongTimeString());
            return _inventoryCheck.CustomItemsWithTargetUserRate(rate);
        }
    }
}
