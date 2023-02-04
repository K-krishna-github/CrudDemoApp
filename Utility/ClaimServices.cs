using System.Security.Claims;

namespace CrudDemoApp.Utility
{
    public class ClaimServices
    {
        private readonly HttpContextAccessor _contextAccessor;

        public ClaimServices(HttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetCurrentUserId()
        {
            var value = _contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty;
            int.TryParse(value, out int res);
            return res;
        }
    }
}
