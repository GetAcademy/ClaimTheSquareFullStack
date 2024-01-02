using ClaimTheSquareFullStack.ViewModel;

// Pause til 11:05

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
var textObjects = new List<TextObject>();
app.MapGet("/textobjects", () =>
{
    return textObjects;
});
app.MapPost("/textobjects", (TextObject textObject) =>
{
    textObjects.Add(textObject);
});
app.UseStaticFiles();
app.Run();
