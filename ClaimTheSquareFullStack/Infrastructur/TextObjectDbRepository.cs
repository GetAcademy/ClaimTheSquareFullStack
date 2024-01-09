using System.Collections.Generic;
using System.Data.SqlClient;
using ClaimTheSquareFullStack.DbModels;
using ClaimTheSquareFullStack.DomainServices;
using Dapper;

namespace ClaimTheSquareFullStack.Infrastructur
{
    public class TextObjectDbRepository : ITextObjectRepository
    {
        private SqlConnectionFactory _connectionFactory;

        public TextObjectDbRepository(SqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<TextObject>> ReadAll()
        {
            var conn = _connectionFactory.Create();
            var sql = @"
                SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
                FROM TextObject t
                JOIN Color c1 ON t.ForeColor = c1.Id
                JOIN Color c2 ON t.BackColor = c2.Id
            ";
            var textObjects = await conn.QueryAsync<TextObject>(sql);
            return textObjects;
        }

        public async Task<TextObject> ReadOne(int index)
        {
            var conn = _connectionFactory.Create();
            var sql = @"
                SELECT t.[Index], t.Text, c1.Color ForeColor, c2.Color BackColor
                FROM TextObject t
                JOIN Color c1 ON t.ForeColor = c1.Id
                JOIN Color c2 ON t.BackColor = c2.Id
                WHERE t.[Index] = @Index
            ";
            var textObjects = await conn.QueryAsync<TextObject>(sql, new { Index = index });
            return textObjects.FirstOrDefault();
        }

        public async Task<bool> Create(TextObjectInt textObject)
        {
            var conn = _connectionFactory.Create();
            var sql = @"INSERT INTO TextObject VALUES (@Index, @Text, @ForeColor, @BackColor)";
            var rowsAffected = await conn.ExecuteAsync(sql, textObject);
            return rowsAffected == 1;
        }
    }
}
