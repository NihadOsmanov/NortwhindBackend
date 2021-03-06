using FluentValidation;

namespace Core.CrossCuttingConcerns.Validaton.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validation(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext)entity);
            if(!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
