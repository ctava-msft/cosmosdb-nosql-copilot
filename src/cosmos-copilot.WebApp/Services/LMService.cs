
using Microsoft.SemanticKernel;
using OpenAI;

namespace Cosmos.Copilot.Services;
public class LMService
{

    private readonly SemanticKernelService _semanticKernelService;


    public LMService(SemanticKernelService semanticKernelService)
    {
        _semanticKernelService = semanticKernelService;

        // Initialize the Semantic Kernel
        var builder = Kernel.CreateBuilder();

        var deploymentName =  Environment.GetEnvironmentVariable("LLM_MODEL_DEPLOYMENT_NAME");
        var apiKey = Environment.GetEnvironmentVariable("API_KEY");
        var endpoint = Environment.GetEnvironmentVariable("ENDPOINT");

        #pragma warning disable SKEXP0010
        builder.Services.AddAzureOpenAITextEmbeddingGeneration(
            deploymentName: deploymentName,
            endpoint: endpoint,           
            apiKey: apiKey
        );

        builder.Services.AddTransient((serviceProvider)=> {
            return new Kernel(serviceProvider);
        });

    }

}
