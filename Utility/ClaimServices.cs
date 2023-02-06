using System.Security.Claims;

namespace CrudDemoApp.Utility
{
    public class ClaimServices
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ClaimServices(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public int GetCurrentUserId()
        {
            var value = _contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value ?? string.Empty;
            int.TryParse(value, out int res);
            return res;
        }

        public string GetCurrentUsername()
        {
            var value = _contextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
            return value;
        }
    }
}
