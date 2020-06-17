using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserData userData;
        [BindProperty]
        public new User User { get; set; }
        public string Message { get; set; }
        public CreateUserModel(IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {
            Message = userData.GetMessage();
            if (Message == null)
            {
                Message = string.Empty;
            }
        }
        public IActionResult OnPost()
        {
          var user = userData.GetByLogin(User);
            if (user != null)
            {
                userData.SetMessage("Użytkownik o takim loginie istnieje, wybierz inny");
                userData.GetMessage();   
                return RedirectToPage("./CreateUser");
            }
            else
            {
                userData.Add(User);
                userData.AddBudget();
                userData.Commit();
                userData.SetMessage(string.Empty);
                return RedirectToPage("./UserCreated");
            }
        }
    }
}