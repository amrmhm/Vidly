using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18AMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.UnKnow || customer.MemberShipTypeId == MemberShipType.PayAsYouGo )
                return ValidationResult.Success;

            if (customer.BirthDay == null)
                return new ValidationResult("Please Enter Birth Date");

            var age = DateTime.Today.Year - customer.BirthDay.Value.Year ;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("Customer SHould Be Least 18 Year Old");
        }
    }
}