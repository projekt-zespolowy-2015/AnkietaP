//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnkietaP.Models

{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using Validators;

    public partial class mieszkaniec
    {
        public int id_mieszkaniec { get; set; }
        [Required]
        [IsPesel]
        [Display(Name = "Podaj pesel")]
        public string pesel { get; set; }
        [Required]
        public string imie { get; set; }
        [Required]
        public string nazwisko { get; set; }

        [Required]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{9,10}$", ErrorMessage = "Numer w formacie 600600600")]
        [Display(Name = "Phone Number")]
        public string telefon { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
