using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.WebApplication.Pages.Global.User;

[Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
public class IndexModel : PageModel
{
    private readonly UserManager<Core.Data.Entities.User> _userManager;

    public IndexModel(UserManager<Core.Data.Entities.User> userManager)
    {
        Users = new List<Core.Data.Entities.User>();
        _userManager = userManager;
    }

    [BindProperty(Name = "p", SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    [BindProperty(Name = "z", SupportsGet = true)]
    public int PageSize { get; set; } = 20;

    [BindProperty(Name = "q", SupportsGet = true)]
    public string Query { get; set; }

    public long Total { get; set; }

    public IReadOnlyCollection<Core.Data.Entities.User> Users { get; set; }

    public virtual async Task<IActionResult> OnGetAsync()
    {
        var query = _userManager
            .Users
            .OrderBy(u => u.DisplayName)
            .AsNoTracking();

        if (Query.HasValue())
            query = query.Where(u => u.DisplayName.Contains(Query) || u.Email.Contains(Query));

        Total = await query
            .CountAsync();

        Users = await query
            .Paginate(PageNumber, PageSize)
            .ToListAsync();

        return Page();
    }
}
