using Cercos.Database;

namespace Cercos.Services
{
    public class OrdersService : DatabaseManager
    {
        public void Insert(int clientId, int shapeId)
        {
            const string query = @"INSERT INTO Orders (ClientId,ShapeId) VALUES (@ClientId,@ShapeId)";
            Insert(query, new()
            {
                new("@ClientId", clientId),
                new("@ShapeId", shapeId),
            });
        }
    }
}