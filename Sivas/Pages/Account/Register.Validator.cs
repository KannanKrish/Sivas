namespace SivasCore.Pages.Account;

public class RegisterValidator : AbstractValidator<RegisterModel>
{
    public RegisterValidator()
    {
        RuleFor(s => s.Username).NotEmpty();
        RuleFor(s => s.Password).NotEmpty().MinimumLength(8);
        RuleFor(s => s.ConfirmPassword).NotEmpty().MinimumLength(8).Equal(s => s.Password);
    }
}