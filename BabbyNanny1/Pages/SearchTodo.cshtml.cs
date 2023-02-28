using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabbyNanny.Data;
using BabbyNanny.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BabbyNanny.Pages
{
    [Authorize]
    public class SearchTodoModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SearchTodoModel(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public bool HasSearch { get; set; }

        [BindProperty]
        public string SearchString { get; set; }

        [BindProperty]
        public string TodoCategory { get; set; }

        [BindProperty]
        public string TodoPriority { get; set; }

        public List<ToDo> SearchResults { get; set; }

        public async Task FillDropDownLists()
        {
            var allCategories = await (from c in _context.TodoCategories
                                       orderby c.Category
                                       select c.Category).Distinct().ToListAsync();

            var categoryItems = new SelectList(allCategories).ToList();


            ViewData["DDListCat"] = categoryItems;

            //Populate a DropDownList using ViewData without database
            List<SelectListItem> DDListPri = new()
            {
                new SelectListItem { Text = "Not important", Value = "Not important" },
                new SelectListItem { Text = "Important", Value = "Important" },
                new SelectListItem { Text = "Very important", Value = "Very important" }
            };
            ViewData["DDListPri"] = DDListPri;
        }

        public List<ToDo> Search(string task,
                        string priority,
                        string category)
        {
            var allTodos = _context.Todos.AsQueryable();

            if (!string.IsNullOrEmpty(task))
            {
                allTodos = allTodos.Where(x => x.Task.ToLower().Contains(task.ToLower()));
            }
            if (!string.IsNullOrEmpty(priority))
            {
                allTodos = allTodos.Where(x => x.Priority.Equals(priority));
            }
            if (!string.IsNullOrEmpty(category))
            {
                allTodos = allTodos.Where(x => x.Category.Equals(category));
            }


            return allTodos.ToList();
        }


        public async Task OnGet(string task,
                       string priority,
                       string category)
        {
            await FillDropDownLists();

            SearchString = task;
            TodoPriority = priority;
            TodoCategory = category;

            //Require all fields
            if (!string.IsNullOrEmpty(task) && !string.IsNullOrEmpty(priority) && !string.IsNullOrEmpty(category))
            {
                HasSearch = true;
                SearchResults = Search(task, priority, category);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                RedirectToPage("./Index");
                //return Page();
            }
            await FillDropDownLists();

            return RedirectToPage("/SearchTodo", new
            {
                task = SearchString,
                priority = TodoPriority,
                category = TodoCategory
            });
        }

    }
}
