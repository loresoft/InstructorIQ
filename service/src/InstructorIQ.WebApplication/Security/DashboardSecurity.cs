using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace InstructorIQ.WebApplication.Security
{
    public class DashboardAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var user = httpContext.User;

            return user.Identity.IsAuthenticated
                && user.IsInRole(Core.Data.Constants.Role.GlobalAdministrator);
        }
    }
}
