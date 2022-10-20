using RandomImageProviderApi.Model;

namespace RandomImageProviderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            
            string relativeImagesFolder = builder.Configuration.GetValue<string>("Settings:RelativeImagesFolder");
            string rootPath = Path.GetFullPath(".");
            builder.Services.AddSingleton<IImageProvider>(_ => new RandomImageFromFilesystemProvider(Path.Combine(rootPath, relativeImagesFolder)));
            
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}