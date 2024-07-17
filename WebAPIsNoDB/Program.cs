namespace WebAPIsNoDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(); // the app will know to look for controllers 
            
            var app = builder.Build();
            app.MapControllers(); // maps the routes with the methods
            app.Run();
        }
    }
}
