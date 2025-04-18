﻿using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

Console.WriteLine("Hello Citizen AI World");
Console.WriteLine("===============");

IChatCompletionService chatService = new AzureOpenAIChatCompletionService("gpt-4.5-preview", "https://aihubcitizenof7688094729.openai.azure.com/", Environment.GetEnvironmentVariable("AI:AzureOpenAI:Key")); 

ChatHistory history = new();

while (true)
{
    Console.Write("Question ? : ");
    history.AddUserMessage(Console.ReadLine());

    var assistant = await chatService.GetChatMessageContentAsync(history);
    history.Add(assistant);
    Console.WriteLine(assistant);
}