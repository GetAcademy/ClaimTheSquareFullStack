/*
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
