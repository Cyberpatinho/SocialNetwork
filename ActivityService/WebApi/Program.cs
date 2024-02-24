using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

await app.ConfigureApplication();

app.Run();
