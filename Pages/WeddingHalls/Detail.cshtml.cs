using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeddingApp.Core;
using WeddingApp.Data;

namespace WeddingApp.Pages.WeddingHalls
{
    public class DetailModel : PageModel
    {
        private readonly IWeddingHallData weddingHallData;
        public WeddingHall WeddingHall { get; set; }
        public DetailModel(IWeddingHallData weddingHallData)
        {
            this.weddingHallData = weddingHallData;
        }
        public void OnGet(int weddingHallId)
        {
            WeddingHall = weddingHallData.GetById(weddingHallId);
        }
    }
}