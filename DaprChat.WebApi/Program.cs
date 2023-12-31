using DaprChat.WebApi.Actors;

using DaprChat.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IChatService, ChatService>();

builder.Services.AddControllers();

builder.Services.AddActors(options => {

    // Register actor types and configure actor settings
    options.Actors.RegisterActor<ChatActor>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment()) {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapActorsHandlers();

app.Run();
