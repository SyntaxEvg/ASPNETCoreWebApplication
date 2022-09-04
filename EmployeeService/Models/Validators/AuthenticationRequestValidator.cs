using EmployeeService.Data;
using EmployeeService.Models.Requests;
using FluentValidation;

namespace EmployeeService.Models.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .Length(7, 255)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .Length(5, 30);

        }
    }
    public class AccountDTOREGValidator : AbstractValidator<AccountDTOREG>
    {
        public AccountDTOREGValidator()
        {
            RuleFor(x => x.EMail)
                .NotNull()
                .Length(7, 255)
                .EmailAddress();
            RuleFor(x => x.Password)
               .NotNull()
               .Length(5, 30);
            RuleFor(x => x.FirstName)
              .NotNull()
              .Length(5, 255); 
            RuleFor(x => x.LastName)
              .NotNull()
              .Length(5, 255);
           RuleFor(x => x.SecondName)
              .NotNull()
              .Length(5, 255);
        }
    }
}
