/*
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
*/