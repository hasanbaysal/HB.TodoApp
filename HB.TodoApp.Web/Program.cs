using HB.TodoApp.Business.DependencyResolvers.Microsoft;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//business layet dependencies
builder.Services.AddDependencies(x =>
{
    x.ConnectionString = builder.Configuration.GetConnectionString("SqlCon")!;
});



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
