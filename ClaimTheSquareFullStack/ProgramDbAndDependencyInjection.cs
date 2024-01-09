/*
using System.Data.SqlClient;using ClaimTheSquareFullStack;
using ClaimTheSquareFullStack.DbModels;
using ClaimTheSquareFullStack.DomainServices;
using ClaimTheSquareFullStack.Infrastructur;
using Dapper;
using TextObject = ClaimTheSquareFullStack.ViewModel.TextObject;

var builder = WebApplication.CreateBuilder(args);


var connStr = builder.Configuration.GetConnectionString("TextObjectsDb");
var connectionFactory = new SqlConnectionFactory(connStr);
builder.Services.AddSingleton<SqlConnectionFactory>(connectionFactory);
builder.Services.AddScoped<ITextObjectRepository, TextObjectDbRepository>();
//builder.Services.AddTransient()
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/textobjects", async (ITextObjectRepository textObjectRepository) =>
{
    return textObjectRepository.ReadAll();
});

app.MapGet("/textobjects/{index}", async (int index, ITextObjectRepository textObjectRepository) =>
{
    return textObjectRepository.ReadOne(index);
});

app.MapPost("/textobjects", async (TextObject textObject, ITextObjectRepository textObjectRepository) =>
{
    var dbTextObject = new TextObjectInt(textObject.Index, textObject.Text, textObject.ForeColor, textObject.BackColor);
    // if(farge og tekst begynner på samme bokstav)
    return textObjectRepository.Create(dbTextObject);
});
app.UseStaticFiles();
app.Run();

*/