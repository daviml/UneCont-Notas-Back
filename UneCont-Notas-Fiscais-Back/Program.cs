var builder = WebApplication.CreateBuilder(args);

// Adiciona o CORS para permitir requisi��es de outras origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Adiciona os servi�os ao cont�iner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona o seu servi�o de notas fiscais
builder.Services.AddSingleton<NotasFiscaisService>();

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// UseAuthentication e UseAuthorization devem vir antes do UseCors
app.UseAuthorization();

// A chamada para UseCors deve vir antes de Mapear os Controllers
app.UseCors("AllowAll");

app.MapControllers();

app.Run();