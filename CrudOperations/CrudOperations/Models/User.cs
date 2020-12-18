using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CrudOperations.Models
{
    public class User
    {

        public int id { get; set; }

        [Required(ErrorMessage = "Adı alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }

        //[NotMapped]
        //[Required(ErrorMessage = "Şifre onay alanı zorunludur.")]
        //[System.ComponentModel.DataAnnotations.Compare("Password")]
        //public string ConfirmPassword { get; set; }

        //public string FullName()
        //{
        //    return this.FirstName + " " + this.LastName;

        //}
    }
}