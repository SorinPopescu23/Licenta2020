using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class User//: IValidatableObject
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Abonat> Abonati { get; set; }


        /*IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
         {
             Licenta1Context db = new Licenta1Context();
             List<ValidationResult> validationResult = new List<ValidationResult>();
             var validateEmail = db.Useri.FirstOrDefault(x => x.Email == Email && x.UserId != UserId);
           // var validatePassword = db.Useri.FirstOrDefault(x => x.Password == Password && x.UserId != UserId);
            if (validateEmail != null)
             {
                 ValidationResult errorMessage = new ValidationResult
                 ("Email already exists.", new[] { "Email" });
                 validationResult.Add(errorMessage);
                 return validationResult;
             }
             else
             {
                 return validationResult;
             }
           
            if (validatePassword != null)
            {
                ValidationResult errorMessage = new ValidationResult
                ("Password already exists.", new[] { "Password" });
                validationResult.Add(errorMessage);
                return validationResult;
            }
            else
            {
                return validationResult;
            }
        }*/
    }
}