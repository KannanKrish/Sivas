namespace SivasCore.Pages.Account;

public partial class Register
{
    [Inject] private IAuthService AuthService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private RegisterModel RegisterModel { get; set; } = new();

    private async void OnRegister()
    {
        var result = await AuthService.Register(RegisterModel.Username, RegisterModel.Password);

        if (result.Success) OnBack();
        else
        {
            RegisterModel.Message = result.Errors.FirstOrDefault() ?? "Error while registering.";

            StateHasChanged();
        }
    }

    private void OnBack() => NavigationManager.NavigateTo("/account/login");
}