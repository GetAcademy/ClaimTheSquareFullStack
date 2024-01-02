using ClaimTheSquareFullStack.ViewModel;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/textobjects", () =>
{
    return new TextObject[]{
        new TextObject(17, "Terje", "green", "white")
    };
});
app.UseStaticFiles();
app.Run();
