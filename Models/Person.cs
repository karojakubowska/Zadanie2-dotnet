﻿using System.ComponentModel.DataAnnotations;

namespace LataPrzestepne.Models
{
    public class Person
    {

        public int Id { get; set; } 
        [Display(Name = "Rok")]
        [Required(ErrorMessage = "Pole Rok jest obowiązkowe"), Range(1899, 2022, ErrorMessage = "Oczekiwana wartość z zakresu {1} i {2}.")]
        public int Year { get; set; }

        [Display(Name = "Imię")]
        [StringLength(100, MinimumLength = 1)]
        [Required(ErrorMessage = "Pole Imię jest obowiązkowe")]
        public string Name { get; set; }

        [Display(Name = "Nazwisko")]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }

        [Display(Name = "Rok przestępny")]
        public bool LeapYear { get; set; }

        [Display(Name = "Data")]
        public DateTime? Date { get; set; }

        [Display(Name = "Wynik")]
        public string? Result { get; set; }  
 
        public string CzyRokPrzestepny()
        {
            if (Year % 4 == 0 && !(Year % 100 == 0) || Year % 400 == 0) 
            {
                return Name+" urodził się w " + Year + " roku. To był rok przestępny";
            }
            return  Name + " urodził się w " + Year + " roku. To nie był rok przestępny";
        }

        public bool RokPrzestepny()
        {
            if (Year % 4 == 0 && !(Year % 100 == 0) || Year % 400 == 0)
            {
                return true;
            }
            return false;
        }

    }
}
