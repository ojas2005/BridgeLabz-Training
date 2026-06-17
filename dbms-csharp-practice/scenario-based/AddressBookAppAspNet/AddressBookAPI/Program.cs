using AddressBookAPI.Services;
using AddressBookAPI.Services.Cache;
using AddressBookAPI.Services.Logging;
using AddressBookAPI.Services.Queue;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Add Swagger - simplified version
builder.Services.AddSwaggerGen();

//Add Redis
var redisConnectionString = builder.Configuration.GetValue<string>("Redis:ConnectionString") ?? "localhost:6379";
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(redisConnectionString));

//Add custom services
builder.Services.AddSingleton<IApplicationLogger, ApplicationLogger>();
builder.Services.AddSingleton<IRedisService, RedisService>();
builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

//Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Address Book API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();