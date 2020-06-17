using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.WeddingHalls
{
    public class EditModel : PageModel
    {
        private readonly IWeddingHallData weddingHallData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public WeddingHall WeddingHall { get; set; }
        public IEnumerable<SelectListItem> Qualities{ get; set; }
        public EditModel(IWeddingHallData weddingHallData, IHtmlHelper htmlHelper)
        {
            this.weddingHallData = weddingHallData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? weddingHallId)
        {
            Qualities = htmlHelper.GetEnumSelectList<Quality>();
            if (weddingHallId.HasValue)
            {
                WeddingHall = weddingHallData.GetById(weddingHallId.Value);
            }
            else
            {
                WeddingHall = new WeddingHall();
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Qualities = htmlHelper.GetEnumSelectList<Quality>();
                return Page();
             }
            if (WeddingHall.Id > 0)
            {
                weddingHallData.Update(WeddingHall);
            }
            else
            {
                weddingHallData.Add(WeddingHall);
            }
            weddingHallData.Commit();
            return RedirectToPage("./Detail", new { WeddingHallId = WeddingHall.Id });
        }   
    }
}