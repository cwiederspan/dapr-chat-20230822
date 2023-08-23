using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace DaprChat.WebApi.Actors {

    public interface IChatActor : IActor {

        Task<string> Chat(/*string prompt*/);
    }

    public class ChatActor : Actor, IChatActor {

        public ChatActor(ActorHost host) : base(host) {

        }

        public async Task<string> Chat(/*string prompt*/) {

            string prompt = "Testing!!!";

            string id = this.Id.GetId();

            //Console.WriteLine($"This is Actor id {this.Id} with data {data}.");

            //// Set State using StateManager, state is saved after the method execution.
            //await this.StateManager.SetStateAsync<MyData>(StateName, data);

            return await Task.FromResult($"Actor {id} says: {prompt}");
        }
    }
}
