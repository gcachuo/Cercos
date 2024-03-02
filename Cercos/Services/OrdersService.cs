using System.Collections;
using Cercos.Database;
using Cercos.Model;

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

        public IEnumerable GetAll()
        {
            const string query =
                "SELECT o.Id,c.Name Client, s.Name Shape FROM Orders o inner join Clients c on c.Id=o.ClientId inner join Shapes S on S.Id = o.ShapeId;";
            return Select<Order>(query);
        }
    }
}