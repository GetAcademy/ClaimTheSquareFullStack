using System.Text.Json;
using ClaimTheSquareFullStack.ViewModel;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

var filename = "textObjects.json";
app.MapGet("/textobjects", async () =>
{
    var files = Directory.GetFiles(".", "*.json");
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
    await File.WriteAllTextAsync(textObject.Index + ".json", json);
});
app.UseStaticFiles();
app.Run();

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