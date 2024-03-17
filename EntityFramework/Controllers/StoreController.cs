using Microsoft.AspNetCore.Mvc;
using Store.Data.Services;

namespace EntityFramework.Controllers
{
    [Route("api/v1/[controller]/stores")]
    [ApiController]
    public class StoreController(ILogger<StoreController> logger, IStoreService storeService) : ControllerBase
    {
        private readonly ILogger<StoreController> _logger = logger;
        private readonly IStoreService _storeService = storeService;

        [HttpGet]
        public async Task<IActionResult> GetAllStoresAsync(CancellationToken cancellationToken)
        {
            var result = await _storeService.GetStoresAsync(cancellationToken);

            if (result.isError)
                return BadRequest(result);

            return Ok(result.Value);
        }
    }
}
