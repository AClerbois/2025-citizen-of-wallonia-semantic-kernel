﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.Web;
using Microsoft.SemanticKernel.Plugins.Web.Bing;

Console.WriteLine("Hello Citizen AI World");
Console.WriteLine("===============");

// Initialization of the service collection
ServiceCollection c = new();

c.AddAzureOpenAIChatCompletion("gpt-4.5-preview", "https://aihubcitizenof7688094729.openai.azure.com/", Environment.GetEnvironmentVariable("AI:AzureOpenAI:Key"));
c.AddKernel();
IServiceProvider services = c.BuildServiceProvider();

// Importing the plugin
Kernel kernel = services.GetRequiredService<Kernel>();
kernel.ImportPluginFromObject(new WebSearchEnginePlugin(new BingConnector(Environment.GetEnvironmentVariable("AI:Bing:Key"))));

// Getting the chat service
IChatCompletionService chatService = services.GetRequiredService<IChatCompletionService>();

PromptExecutionSettings settings = new AzureOpenAIPromptExecutionSettings()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};

ChatHistory history = new();

while (true)
{
    Console.Write("Question ? : ");
    history.AddUserMessage(Console.ReadLine());

    var assistant = await chatService.GetChatMessageContentAsync(history, settings, kernel);
    history.Add(assistant);
    Console.WriteLine(assistant);
}