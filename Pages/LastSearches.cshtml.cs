using LataPrzestepne.Data;
using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LataPrzestepne.Pages
{
    public class OstatnioSzukaneModel : PageModel
    {
        public Person Person { get; set; }
        private readonly PeopleContext _context;
        public List<Person> Osoby = new List<Person>();
        public OstatnioSzukaneModel( PeopleContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
           /* var top20 = from p in _context.Person
                        orderby p.Date descending
                        select p;*/
           var top20= _context.Person.OrderByDescending(person => person.Date).Take(20);
           Osoby=top20.ToList();
        }
        
    }
}
