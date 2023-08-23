# Dapr Chat App

A Dapr-implemented OpenAI chat service demo.

```bash

dapr run --dapr-http-port 3500 --app-id myapp --app-port 5000 -- dotnet run

curl -X POST http://127.0.0.1:3500/v1.0/actors/ChatActor/999/method/Chat -d '{ "content": "Hello, World!" }'


curl -v http://127.0.0.1:5000/chat

curl -v -X POST http://127.0.0.1:5000/chat/999 -d 'This is a test!!!'

curl -v -H 'Content-Type: application/json' -X POST http://127.0.0.1:5000/chat/fe03df2c-b426-481a-961b-4a5db2390ab2 -d '{ "content": "Hello, World!" }'

```
