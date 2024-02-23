namespace SivasCore.Pages.Account;

public partial class Login
{
    [Inject] private IAuthService AuthService { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private LoginModel Model { get; set; }

    private string Error { get; set; }

    private EditContext editContext;

    protected override void OnInitialized()
    {
        Model = new LoginModel("", "");

        Error = string.Empty;

        editContext = new EditContext(Model);
    }

    private async void OnLogin()
    {
        var result = await AuthService.Login(Model.Username, Model.Password);

        if (result.Success)
        {
            NavigationManager.TryGetQueryString<string>("returnUrl", out var returnUrl);
            NavigationManager.NavigateTo($"/{returnUrl}");
        }
        else
        {
            Error = result.Errors.First();

            StateHasChanged();
        }
    }
}