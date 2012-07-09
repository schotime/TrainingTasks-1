using System;
using System.Collections.Generic;

namespace TrainingTasks1
{
    public class PasswordValidation : IPasswordValidation 
    {
        private readonly IEnumerable<IPasswordValidator> _validators;

        public PasswordValidation(IEnumerable<IPasswordValidator> validators)
        {
            _validators = validators;
        }

        public PasswordValidationResult Validate(string password)
        {
            foreach (var validator in _validators)
            {
                if (!validator.IsValid(password))
                {
                    return new PasswordValidationResult {IsValid = false, Message = validator.Message};
                }
            }
            return new PasswordValidationResult() { IsValid = true };
        }
    }
}