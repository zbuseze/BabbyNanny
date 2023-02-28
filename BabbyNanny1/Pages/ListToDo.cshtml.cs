using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabbyNanny.Data;
using BabbyNanny.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BabbyNanny.Pages
{
    [Authorize]
    public class ListToDoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<WebUser> _userManager;

        public ListToDoModel(UserManager<WebUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IList<ToDo> Todos { get; set; }
        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count != 0)
            {
                if (roles[0].ToString() == "Admin")
                {
                    Todos = await _context.Todos.ToListAsync();
                }
                // you can also check other roles
                // e.g. else if (roles[0].ToString() == "DatabseAdmin")
                // ...
            }
            else
            {
                Todos = await _context.Todos.Where(u => u.UserId.Equals(userId))
                                            .Where(t => t.IsApproved == true).ToListAsync();
            }
        }
    }
}
