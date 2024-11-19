using Login_Signup.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LoginRegistrationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
builder.Services.AddMvc();
builder.Services.AddSession();
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute(name:"default",pattern:"{controller=Login_Signup}/{action=Register}");
app.Run();
