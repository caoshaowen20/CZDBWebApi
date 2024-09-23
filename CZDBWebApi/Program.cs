using CZDBHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbv4_path = Path.Combine(AppContext.BaseDirectory, "cz88_public_v4.czdb");
string dbv6_path = Path.Combine(AppContext.BaseDirectory, "cz88_public_v6.czdb");

string key = "GKSVaGlNNJRPDB2K7NTgtg==";

builder.Services.AddSingleton<DbIpv4Searcher>(new DbSearcher(dbv4_path, QueryType.MEMORY, key));
builder.Services.AddSingleton<DbIpv6Searcher>(new DbSearcher(dbv6_path, QueryType.MEMORY, key));

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