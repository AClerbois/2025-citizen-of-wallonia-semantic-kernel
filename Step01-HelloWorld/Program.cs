using System.ClientModel;
using OpenAI;
using OpenAI.Chat;

Console.WriteLine("Hello Citizen AI World");
Console.WriteLine("===============");

OpenAIClient client = new OpenAIClient(new ApiKeyCredential(Environment.GetEnvironmentVariable("AI:OpenAI:Key")));
ChatClient chatService = client.GetChatClient("gpt-4o-mini");

var result = await chatService.CompleteChatAsync("Quelle est la couleur du ciel ? Donnes moi une réponse en maximum 3 mots"); 
Console.WriteLine(result.Value.Content.First().Text);