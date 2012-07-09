using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks1
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        // 1. Should implement 3 rules (must have a number, must have an uppercase letter, must be min of 10 in length). More may be needed later.
        // 2. A Blank password is not valid (First test stub below)
        // 3. If a password is invalid the reason it is invalid should be in the ValidationResult 
        //
        // Notes: Tests should cover all functionality
        //        C# conventions should be followed

        private IPasswordValidation GetPasswordValidation()
        {
            return new PasswordValidation(new IPasswordValidator[]
            {
                new NotNullOrEmptyValidator(),
                new NumberPasswordValidator(),
                new UpperCasePasswordValidator(),
                new MinLengthPasswordValidator()
            });
        }

        [Test]
        public void A_Blank_Password_Is_Not_Valid()
        {
            IPasswordValidator validator = new NotNullOrEmptyValidator();
            var result = validator.IsValid("");

            Assert.False(result);
            Assert.AreEqual(validator.Message, "Password cannot be blank");
        }

        [Test]
        public void A_Null_Password_Is_Not_Valid()
        {
            IPasswordValidator validator = new NotNullOrEmptyValidator();
            var result = validator.IsValid(null);

            Assert.False(result);
            Assert.AreEqual(validator.Message, "Password cannot be blank");
        }

        [Test]
        public void A_Password_With_No_Uppercase_Is_Not_Valid()
        {
            IPasswordValidator validator = new UpperCasePasswordValidator();
            var result = validator.IsValid("xxxxx");

            Assert.False(result);
            Assert.AreEqual(validator.Message, "You must have 1 upper case character");
        }

        [Test]
        public void A_Password_With_No_Number_Is_Not_Valid()
        {
            IPasswordValidator validator = new NumberPasswordValidator();
            var result = validator.IsValid("xxxxx");

            Assert.False(result);
            Assert.AreEqual(validator.Message, "You must have 1 number");
        }

        [Test]
        public void A_Password_Less_Than_10_Characters_Is_Not_Valid()
        {
            IPasswordValidator validator = new MinLengthPasswordValidator();
            var result = validator.IsValid("xxxxx");

            Assert.False(result);
            Assert.AreEqual(validator.Message, "You must enter 10 or more characters");
        }

        [Test]
        public void A_Password_With_10_Chars_A_Number_An_UpperCase_Is_Valid()
        {
            IPasswordValidation validation = GetPasswordValidation();
            var result = validation.Validate("Afdsfdfsd2");

            Assert.True(result.IsValid);
            Assert.AreEqual(result.Message, null);
        }

        [Test]
        public void An_Incorrect_Password_Returns_Error_Message()
        {
            IPasswordValidation validation = GetPasswordValidation();
            var result = validation.Validate("xxxxx");

            Assert.False(result.IsValid);
            Assert.NotNull(result.Message);
        }
    }
}
