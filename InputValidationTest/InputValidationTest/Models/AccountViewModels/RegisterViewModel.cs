using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InputValidationTest.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required] //Data range: kötelező megadni
        [EmailAddress] //Data formatting: csak ami email címet jelent
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required] //data range: kötelező megadni
        //data range: 0-100 karakter hosszú lehet
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //Data type/data formatting: csillagokkal jelzi az adatbevitelt
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //meg kell egyeznie a Password mező tartalmával
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
