using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LataPrzestepne.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Osoba Osoba { get; set; }
        public List<Osoba> Osoby = new List<Osoba>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TempData["Results"] = Osoba.CzyRokPrzestepny();

            if (HttpContext.Session.GetString("DataList") == null)
            {
                Osoby.Add(Osoba);
                HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(Osoby));
            }
            else 
            { 
                var SessionList = HttpContext.Session.GetString("DataList");
                Osoby = JsonConvert.DeserializeObject<List<Osoba>>(SessionList);
                Osoby.Add(Osoba);
                HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(Osoby));
            }
            return Page(); ;
        }
    }
}