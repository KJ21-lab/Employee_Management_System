using HabitClass;

public class Program
{
    public static List<Habit> habits = new List<Habit>
    {
        new Habit(1, "Read Daily", "Read at least 15 minutes of a non-fiction book every day.")
    };

    private static int nextId = 1;

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // --- IMPORTANT ADDITIONS FOR CONTROLLERS ---
        builder.Services.AddControllers(); // This registers services needed for controllers
        // --- END IMPORTANT ADDITIONS ---

        // CORS Configuration.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowSpecificOrigin",
                                 builder =>
                                 {
                                     builder.WithOrigins("http://localhost:3000", "http://localhost:5173")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                 });
        });

        // JSON Options Configuration.
        builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.PropertyNameCaseInsensitive = true;
            options.SerializerOptions.PropertyNamingPolicy = null;
            // options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        var app = builder.Build();

        app.UseCors("AllowSpecificOrigin");
        app.MapControllers(); 
        app.Run();
    }
}

