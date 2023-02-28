using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabbyNanny.Data;
using BabbyNanny.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BabbyNanny.Pages
{
    [Authorize(Roles="Admin")]
    public class ApproveTodoModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<WebUser> _userManager;

        public ApproveTodoModel(UserManager<WebUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IList<ToDo> Todos { get; set; }

        [BindProperty]
        public ToDo Todo { get; set; }
        public async Task OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles[0].ToString() == "Admin")
            {
                Todos = await _context.Todos.ToListAsync();
            }
            


        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var TaskFromDb = await _context.Todos.FindAsync(Todo.Id);
            TaskFromDb.IsApproved = true;
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
