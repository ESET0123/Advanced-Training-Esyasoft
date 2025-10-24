using System.ComponentModel.DataAnnotations;
using System;

namespace CollegeApp.Model.Validations
{
    public class SpaceCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var input = value as string;
            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult("Please enter a valid value.");
            }
            if (input.Contains(" "))
            {
                return new ValidationResult("Spaces are not allowed.");
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                char firstChar = input[0];
                if (!Char.IsUpper(firstChar))
                {
                    return new ValidationResult($"{firstChar} First letter should be capital.");
                }
            }
            return ValidationResult.Success;
        }
    }
    //public class FirstCapitalCheckAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //    {
    //        var input = value as string;
    //        if (!string.IsNullOrWhiteSpace(input))
    //        {
    //            char firstChar = input[0];
    //            if(Char.IsUpper(firstChar))
    //            {
    //                return new ValidationResult("First letter should be capital.");
    //            }
    //        }
    //        return ValidationResult.Success;
    //    }
    //}
}
