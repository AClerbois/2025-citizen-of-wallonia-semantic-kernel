using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

Console.WriteLine("Hello AI World");
Console.WriteLine("===============");

// Initialization of the service collection
ServiceCollection c = new();

c.AddAzureOpenAIChatCompletion("gpt-4.5-preview", "https://aihubcitizenof7688094729.openai.azure.com/", Environment.GetEnvironmentVariable("AI:AzureOpenAI:Key"));
c.AddKernel();
IServiceProvider services = c.BuildServiceProvider();

// Getting the chat service
IChatCompletionService chatService = services.GetRequiredService<IChatCompletionService>();

ChatHistory history = new();

while (true)
{
    Console.Write("Question ? : ");
    history.AddUserMessage(Console.ReadLine());

    var assistant = await chatService.GetChatMessageContentAsync(history);
    history.Add(assistant);
    Console.WriteLine(assistant);
}