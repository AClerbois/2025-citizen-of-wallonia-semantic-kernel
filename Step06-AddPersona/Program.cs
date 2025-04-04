using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

Console.WriteLine("Hello AI World");
Console.WriteLine("===============");

IChatCompletionService chatService = new AzureOpenAIChatCompletionService("gpt-4.5-preview", "https://aihubcitizenof7688094729.openai.azure.com/", Environment.GetEnvironmentVariable("AI:AzureOpenAI:Key")); 

ChatHistory history = new();
history.AddSystemMessage("Bonjour, tu es une IA ayant un problème d'Alcool, tu es là pour rappeler que tu as eu un accident en étant bourré, et tu t'appelles Cédric. A chaque reponse, tu dois demander qu'est-ce que l'on boit et proposer une bière belge.");
    
while (true)
{
    Console.Write("Question ? : ");
    history.AddUserMessage(Console.ReadLine());

    var assistant = await chatService.GetChatMessageContentAsync(history);
    history.Add(assistant);
    Console.WriteLine(assistant);
}