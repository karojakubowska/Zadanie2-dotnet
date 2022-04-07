using LataPrzestepne.Data;
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
        public Person Person { get; set; }
        public List<Person> People = new List<Person>();
        private readonly PeopleContext _context;
        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
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
            TempData["Results"] = Person.CzyRokPrzestepny();

            if (HttpContext.Session.GetString("DataList") == null)
            {
                People.Add(Person);
                HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(People));
            }
            else 
            { 
                var SessionList = HttpContext.Session.GetString("DataList");
                People = JsonConvert.DeserializeObject<List<Person>>(SessionList);
                People.Add(Person);
                HttpContext.Session.SetString("DataList", JsonConvert.SerializeObject(People));
            }
            Person.LeapYear = Person.RokPrzestepny();
            Person.Result= Person.CzyRokPrzestepny();
            DateTime date=DateTime.Now;
            Person.Date = date;
            People = _context.Person.ToList();
            _context.Person.Add(Person);
            _context.SaveChanges();
            return Page(); ;
        }
    }
}