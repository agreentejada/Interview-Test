using Book.Library.Api;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.InitializeDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Restricts the usage of HTTPS to production environment so devs don't have to install a test certificate.
    app.UseHttpsRedirection();
}

app.MapControllers();
app.UseRouting();
// While not currently used, setting the app to use Authentication/Authorization is useful for real world problems.
app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();