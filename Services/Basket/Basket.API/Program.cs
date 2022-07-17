using Basket.API.gRPCServices;
using Basket.API.Repositories;
using Discount.gRPC.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
Console.WriteLine("here"+builder.Configuration.GetConnectionString("RedisCache"));
builder.Services.AddStackExchangeRedisCache(
    opts =>
        opts.Configuration= builder.Configuration.GetConnectionString("RedisCache"));
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
    opts=>opts.Address= new Uri(builder.Configuration.GetConnectionString("GRPCuri"))
    );
builder.Services.AddScoped<DiscountgRPCServices>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();