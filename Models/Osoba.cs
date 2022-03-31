using System.ComponentModel.DataAnnotations;

namespace LataPrzestepne.Models
{
    public class Osoba
    {
        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole Rok jest obowiązkowe"), Range(1899, 2022, ErrorMessage = "Oczekiwana wartość z zakresu {1} i {2}.")]
        public int Rok { get; set; }
        [Display(Name = "Imię")]
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Pole Imię jest obowiązkowe")]
        public string Imie { get; set; }


        public string CzyRokPrzestepny()
        {
            if (Rok % 4 == 0 && !(Rok % 100 == 0) || Rok % 400 == 0) 
            {
                return Imie+" urodził się w " + Rok + " roku. To był rok przestępny";
            }
            return  Imie + " urodził się w " + Rok + " roku. To nie był rok przestępny";
        }

        public bool RokPrzestepny()
        {
            if (Rok % 4 == 0 && !(Rok % 100 == 0) || Rok % 400 == 0)
            {
                return true;
            }
            return false;
        }

    }
}
