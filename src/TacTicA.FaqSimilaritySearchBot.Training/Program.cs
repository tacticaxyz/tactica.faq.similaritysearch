using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using TacTicA.FaqSimilaritySearchBot.Training.Services;
using TacTicA.FaqSimilaritySearchBot.Training.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TacTicA.FaqSimilaritySearchBot.Training;

enum EmbeddingApproach
{
    Simple,
    TfIdf,
    Onnx
};

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("TacTicA.FaqSimilaritySearchBot Training Service");
        Console.WriteLine("================================");

        // Main menu
        Console.WriteLine("Choose operation:");
        Console.WriteLine("0. Cancel");
        Console.WriteLine("1. Train model with Simple (Hash-based) embedding");
        Console.WriteLine("2. Train model with TF-IDF (Keyword-based) embedding");
        Console.WriteLine("3. Compare embedding services");
        Console.WriteLine("4. Train model with ONNX embedding");
        Console.Write("Enter your choice (0-4): ");
        
        var choice = Console.ReadLine();
        EmbeddingApproach approach = EmbeddingApproach.Simple;
        switch (choice)
        {
            case "0":
                return;
            case "1":
                Console.WriteLine("Using Simple (Hash-based) Embedding Service");
                approach = EmbeddingApproach.Simple;
                break;
            case "2":
                Console.WriteLine("Using TF-IDF (Keyword-based) Embedding Service");
                approach = EmbeddingApproach.TfIdf;
                break;
            case "3":
                await EmbeddingComparisonUtil.CompareEmbeddingServices();
                return;
            case "4":
                Console.WriteLine("Using ONNX Embedding Service");
                approach = EmbeddingApproach.Onnx;
                break;
        }

        Console.WriteLine();

        var host = CreateHostBuilder(args, approach).Build();
        
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        try
        {
            var trainingService = services.GetRequiredService<TrainingService>();
            await trainingService.RunAsync();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred during training");
            Environment.Exit(1);
        }
        
        Console.WriteLine("Training completed successfully!");
    }

    static IHostBuilder CreateHostBuilder(string[] args, EmbeddingApproach approach) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Configure settings from appsettings.json
                services.Configure<EmbeddingSettings>(
                    context.Configuration.GetSection("EmbeddingSettings"));
                services.Configure<DataPaths>(
                    context.Configuration.GetSection("DataPaths"));
                services.Configure<ProcessingSettings>(
                    context.Configuration.GetSection("ProcessingSettings"));
                
                // Register the chosen embedding service
                switch (approach)
                {
                    case EmbeddingApproach.Simple:
                        services.AddScoped<IEmbeddingService, SimpleEmbeddingService>();
                        break;
                    case EmbeddingApproach.TfIdf:
                        services.AddScoped<IEmbeddingService, TfIdfEmbeddingService>();
                        break;
                    case EmbeddingApproach.Onnx:
                        services.AddScoped<IEmbeddingService, OnnxEmbeddingService>();
                        break;
                    default:
                        return;
                };

                services.AddScoped<IDataProcessingService, DataProcessingService>();
                services.AddScoped<TrainingService>();
                services.AddHttpClient();
            });
}