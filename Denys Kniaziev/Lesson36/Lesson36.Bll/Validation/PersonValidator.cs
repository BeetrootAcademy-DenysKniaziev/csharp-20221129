using FluentValidation;
using Lesson36.Contracts;

namespace Lesson36.Bll.Validation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Age).GreaterThanOrEqualTo((byte)18).WithMessage("Age should be greater than 18!");
        }
    }
}
