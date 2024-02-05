using System.Security.Claims;
using System.Security.Principal;

namespace SignalR.Chat.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetUserName(this IPrincipal currentPrincipal)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            
            var claim = identity.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType);
            // ?. prevents a exception if claim is null.
            return claim.Value;
            
        }
    }
}
