using System.Data.SqlClient;
using System.Text.Json;
using ClaimTheSquareFullStack.DbModels;
using Dapper;
using TextObject = ClaimTheSquareFullStack.ViewModel.TextObject;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
var connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TextObjects;Integrated Security=True";

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

/*
 Multiple files: 

   var baseDir = AppDomain.CurrentDomain.BaseDirectory + "textobjects\\";
   Directory.CreateDirectory(baseDir);
   
   app.MapGet("/textobjects", async () =>
   {
       var files = Directory.GetFiles(baseDir, "*.json");
       var textObjects = new List<TextObject>();
       foreach (var file in files)
       {
           var json = await File.ReadAllTextAsync(file);
           var textObject = JsonSerializer.Deserialize<TextObject>(json);
           textObjects.Add(textObject);
       }
       return textObjects;
   });
   app.MapPost("/textobjects", async (TextObject textObject) =>
   {
       var json = JsonSerializer.Serialize(textObject);
       var filename = baseDir + textObject.Index + ".json";
       await File.WriteAllTextAsync(filename, json);
   });
 */


/*
   Single file: 

var filename = "textObjects.json";
app.MapGet("/textobjects", async () =>
{
    if (File.Exists(filename))
    {
        var json = await File.ReadAllTextAsync(filename);
        var textObjects = JsonSerializer.Deserialize<TextObject[]>(json);
        return textObjects;
    }

    return new TextObject[0];
});
app.MapPost("/textobjects", async (TextObject textObject) =>
{
    var json = File.Exists(filename) ? await File.ReadAllTextAsync(filename) : "[]";
    var textObjects = JsonSerializer.Deserialize<TextObject[]>(json).ToList();
    textObjects.Add(textObject);
    json = JsonSerializer.Serialize(textObjects);
    await File.WriteAllTextAsync(filename, json);
    return textObjects;

});

 */


/*
 Inmemory: 

var textObjects = new List<TextObject>();
app.MapGet("/textobjects", () =>
{
    return textObjects;
});
app.MapPost("/textobjects", (TextObject textObject) =>
{
    textObjects.Add(textObject);
});

 */