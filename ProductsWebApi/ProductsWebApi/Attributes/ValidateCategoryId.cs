using ProductsWebApi.Data;
using System.ComponentModel.DataAnnotations;

namespace ProductsWebApi.Attributes
{
    public class ValidateCategoryId : ValidationAttribute
    {
        const string ERROR_TEXT = "Invalid category Id";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not int categoryId)
                return new ValidationResult(ERROR_TEXT);

            var category = validationContext.GetService<ApplicationDbContext>()?.Categories.Find(categoryId);

            if (category == null)
                return new ValidationResult(ERROR_TEXT);

            return ValidationResult.Success;
        }
    }
}
