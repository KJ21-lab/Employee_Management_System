// 1. You should also add the following using statement to configure the proxy.
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Replace AddControllersWithViews() with AddControllers() since you are
// no longer serving traditional MVC views.
builder.Services.AddControllers();

// Add the spa services to the project.
builder.Services.AddSpaStaticFiles(configuration => {
    // The folder where the React SPA resides.
    configuration.RootPath = "habittracker_frontend/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 2. Add this line to serve the front-end's files. This should come before app.UseRouting().
// Remove the MVC routing and replace it with a fallback that serves the React app.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// 3. Instead of app.MapControllerRoute, you use a fallback that tells the server
// to serve the index.html file from your React app for any route not found.
app.MapFallbackToFile("index.html");

// 4. This is for development, to use the React development server.
if (app.Environment.IsDevelopment()) {
    app.UseSpa(spa => {
        spa.Options.SourcePath = "habittracker_frontend";
        spa.UseReactDevelopmentServer(npmScript: "dev");
    });
}


app.Run();
