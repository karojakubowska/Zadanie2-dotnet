using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LataPrzestepne.Pages
{
    public class ZapisaneModel : PageModel
    {
        public Person Osoba;
        public List<Person> Osoby = new List<Person>();
        public void OnGet()
        {
            var SessionList = HttpContext.Session.GetString("DataList");
            if (SessionList != null)
            {
                Osoby = JsonConvert.DeserializeObject<List<Person>>(SessionList);
            }
        }

       
    }
}
