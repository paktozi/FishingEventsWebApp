var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppDataBase(builder.Configuration);
builder.Services.AddAppIdentity(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddAppServices(builder.Configuration);

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Errors/ServerError");
    app.UseStatusCodePagesWithReExecute("/Errors/PageNotFound");
    app.UseStatusCodePagesWithReExecute("/Errors/Unauthorized");
    // app.UseExceptionHandler("/Home/Error");     
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();



