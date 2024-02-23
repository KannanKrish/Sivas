var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddBlazorAuthentication<Guid, ApplicationUser, ApplicationRole, ApplicationDbContext>()
    .AddSmartBackend<ApplicationDbContext>(s =>
    {
        s.ResetDatabaseSchema = true;
        s.AutomaticMigrationDataLossAllowed = true;
    })
    .AddSmartCore()
    .AddSmartUI(o =>
    {
        o.AppendTitle = " - Sivas";
        o.DefaultFontAwesome = FontAwesomeType.Solid;
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication<Guid, ApplicationUser>();

app.UseSmartBackend();

//app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.MapDefaultControllerRoute();

app.Run();