using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data
{
    public class DateGreaterThanOrEqualAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanOrEqualAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = value as DateTime?;
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                return new ValidationResult($"Propriedade de comparação '{_comparisonProperty}' não encontrada.");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance) as DateTime?;

            if (currentValue.HasValue && comparisonValue.HasValue)
            {
                if (currentValue.Value < comparisonValue.Value)
                {
                    return new ValidationResult(ErrorMessage ?? $"A data deve ser maior ou igual a '{_comparisonProperty}'.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
