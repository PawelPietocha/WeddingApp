using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.Deadlines
{
    public class BudgetListModel : PageModel
    {
        private readonly IUserData userData;
        public LeftToPay LeftToPay;
        [BindProperty]
        public  Budget1 Budget { set; get; }
        public BudgetListModel(IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
            int i = userData.GetId();
            Budget = userData.GetBudgetById(i);
            LeftToPay = new LeftToPay(Budget);

        }
    }
}