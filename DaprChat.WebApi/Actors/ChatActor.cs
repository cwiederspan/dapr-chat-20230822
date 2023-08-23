using Dapr.Actors;
using Dapr.Actors.Runtime;

using Microsoft.SemanticKernel;

using DaprChat.WebApi.Services;

namespace DaprChat.WebApi.Actors {

    public interface IChatActor : IActor {

        Task<string> Chat(Prompt prompt);
    }

    public class ChatActor : Actor, IChatActor {

        private readonly IChatService ChatService;

        public ChatActor(ActorHost host, IChatService chatService) : base(host) {
            this.ChatService = chatService;
        }

        public async Task<string> Chat(Prompt request) {

            string id = this.Id.GetId();

            var builder = new KernelBuilder();
            builder.WithAzureTextCompletionService("XXX-gpt35turbo-20230526", "https://XXXXXXXX.openai.azure.com/", "XXXXXXXXX");
            builder.WithLogger(this.Logger);
            var kernel = builder.Build();

            var prompt = @"{{$input}}

            One line TLDR with the fewest words.";

            var summarize = kernel.CreateSemanticFunction(prompt, maxTokens: 100);

            string text1 = @"
            1st Law of Thermodynamics - Energy cannot be created or destroyed.
            2nd Law of Thermodynamics - For a spontaneous process, the entropy of the universe increases.
            3rd Law of Thermodynamics - A perfect crystal at zero Kelvin has zero entropy.";

            string text2 = @"
            1. An object at rest remains at rest, and an object in motion remains in motion at constant speed and in a straight line unless acted on by an unbalanced force.
            2. The acceleration of an object depends on the mass of the object and the amount of force applied.
            3. Whenever one object exerts a force on another object, the second object exerts an equal and opposite on the first.";

            Console.WriteLine(await summarize.InvokeAsync(text1));

            var summary1 = await summarize.InvokeAsync(text1);
            var summary2 = await summarize.InvokeAsync(text2);

            //Console.WriteLine($"This is Actor id {this.Id} with data {data}.");

            //// Set State using StateManager, state is saved after the method execution.
            //await this.StateManager.SetStateAsync<MyData>(StateName, data);

            return await Task.FromResult($"Actor {id} says: {request.Content}");
        }
    }
}
