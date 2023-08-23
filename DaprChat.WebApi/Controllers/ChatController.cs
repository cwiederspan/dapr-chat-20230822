using Dapr.Actors;
using Dapr.Actors.Client;
using DaprChat.WebApi.Actors;
using Microsoft.AspNetCore.Mvc;

namespace DaprChat.WebApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase {

        private readonly ILogger<ChatController> Logger;

        public ChatController(ILogger<ChatController> logger) {
            this.Logger = logger;
        }

        [HttpGet]
        public string Get() {

            return "Hello from ChatController!";
        }

        [HttpPost]
        public async Task<string> Post(Guid? id, string prompt) {

            id = id ?? Guid.NewGuid();

            var proxy = ActorProxy.Create<IChatActor>(new ActorId(id.ToString()), "ChatActor");

            var response = await proxy.Chat(new Prompt(prompt));

            return response;
        }
    }
}