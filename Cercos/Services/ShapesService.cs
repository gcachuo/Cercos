using Cercos.Database;

namespace Cercos.Services
{
    public class ShapesService : DatabaseManager
    {
        public void Insert(int clientId, string code, string name)
        {
            const string query = @"INSERT INTO Shapes (ClientId,Code,Name) VALUES (@ClientId,@Code,@Name)";
            Insert(query, new()
            {
                new("@ClientId", clientId),
                new("@Code", code),
                new("@Name", name),
            });
        }
    }
}