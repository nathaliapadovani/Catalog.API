using Catalog.API.Data; // Namespace para classes relacionadas ao acesso a dados
using Catalog.API.Repositories; // Namespace para os reposit�rios
using Microsoft.OpenApi.Models; // Fornece classes para configurar o Swagger

// Base para configurar servi�os e a aplica��o
// Inicia a configura��o da API, substituindo a abordagem do Startup.cs
var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao cont�iner
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
