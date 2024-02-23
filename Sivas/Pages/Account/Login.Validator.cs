namespace SivasCore.Pages.Account;

public class LoginValidator : AbstractValidator<LoginModel>
{
    public LoginValidator()
    {
        RuleFor(s => s.Username).NotEmpty();
        RuleFor(s => s.Password).NotEmpty().MinimumLength(8);
    }
}