using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.Deadlines
{
    public class UpdateBudgetModel : PageModel
    {
        private readonly IUserData userData;
       
        [BindProperty]
        public  Budget1 Budget { get; set; }

        public UpdateBudgetModel( IUserData userData)
        {
            this.userData = userData;
        }
        public IActionResult OnGet()
        {
            int i = userData.GetId();
            Budget = userData.GetBudgetById(i);
            return Page();
        }
        public IActionResult OnPost()
        {
            userData.UpdateBudget(Budget);
            userData.Commit();
            return RedirectToPage("./BudgetList/");
        }
    }
}