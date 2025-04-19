using C__Cumulative_Part_1.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<TeacherAPIController>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<TeacherAPIController>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllers(); 

app.Run();

app.Run();
