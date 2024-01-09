using System.Data.SqlClient;using ClaimTheSquareFullStack;
using ClaimTheSquareFullStack.DbModels;
using Dapper;
using TextObject = ClaimTheSquareFullStack.ViewModel.TextObject;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("TextObjectsDb");
var connectionFactory = new SqlConnectionFactory(connStr);
builder.Services.AddSingleton(connectionFactory);
//builder.Services.AddScoped()
//builder.Services.AddTransient()
var app = builder.Build();
app.UseHttpsRedirection();

// Pause til 10:35


app.MapGet("/textobjects", async () =>
{
    var conn = new SqlConnection(connStr);
    var sql = @"
        SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
        FROM TextObject t
        JOIN Color c1 ON t.ForeColor = c1.Id
        JOIN Color c2 ON t.BackColor = c2.Id
    ";
    var textObjects = await conn.QueryAsync<TextObject>(sql);
    return textObjects;
});

app.MapGet("/textobjects/{index}", async (int index) =>
{
    var conn = new SqlConnection(connStr);
    var sql = @"
        SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
        FROM TextObject t
        JOIN Color c1 ON t.ForeColor = c1.Id
        JOIN Color c2 ON t.BackColor = c2.Id
        WHERE t.[Index] = @Index
    ";
    var textObjects = await conn.QueryAsync<TextObject>(sql, new { Index = index });
    return textObjects.FirstOrDefault();
});

app.MapPost("/textobjects", async (TextObject textObject) =>
{
    var conn = new SqlConnection(connStr);
    var dbTextObject = new
    {
        Index = textObject.Index,
        Text = textObject.Text,
        ForeColor = Enum.Parse<Color>(textObject.ForeColor),
        BackColor = Enum.Parse<Color>(textObject.BackColor)
    };
    var sql = @"INSERT INTO TextObject VALUES (@Index, @Text, @ForeColor, @BackColor)";
    var rowsAffected = await conn.ExecuteAsync(sql, dbTextObject);
    return rowsAffected;
});
app.UseStaticFiles();
app.Run();
