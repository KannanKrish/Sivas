namespace Sivas.Services;

public class AccountService(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager) : IStartupWorkAsync
{
    public async Task DoWorkAsync()
    {
        await roleManager.AddRolesAsync<ApplicationRole, AccountType>();

        await userManager.CreateUsersAsync(new UserModel<AccountType>("kannan", "Super@321", AccountType.Owner));
    }
}