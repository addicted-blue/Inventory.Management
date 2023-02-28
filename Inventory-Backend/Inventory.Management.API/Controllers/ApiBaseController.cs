using Microsoft.AspNetCore.Mvc;

namespace Inventory.Management.API.Controllers
{
    public class ApiBaseController: Controller
    {
        private readonly ILoggerFactory _logerFactory;
        private ILogger _logger;

        public ApiBaseController(ILoggerFactory logerFactory)
        {
            this._logerFactory = logerFactory ?? throw new ArgumentNullException(nameof(logerFactory));
        }

        protected ILogger Logger => this._logger ?? (this._logger = this._logerFactory.CreateLogger(this.GetType().Name));

        public static class Route
        {
            public const string ApiPrefix = "products/api/v{version:apiVersion}";
        }

        public static class RouteParams
        {
            public const string ProductId = "{productId}";
        }
    }
}
