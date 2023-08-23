# Dapr Chat App

A Dapr-implemented OpenAI chat service demo.

```bash

dapr run --dapr-http-port 3500 --app-id myapp --app-port 5000 -- dotnet run

curl -X POST http://127.0.0.1:3500/v1.0/actors/ChatActor/999/method/Chat

```
