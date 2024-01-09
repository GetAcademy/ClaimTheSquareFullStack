/*

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