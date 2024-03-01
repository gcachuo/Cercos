using System.Collections;
using Cercos.Database;
using Cercos.Model;

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

        public IEnumerable GetAll()
        {
            const string query = "SELECT s.Id,c.Name Client,s.Code,s.Name FROM Shapes s inner join Clients c on c.Id=s.ClientId;";
            return Select<Shape>(query);
        }

        public IEnumerable GetAllFromClient(int clientId)
        {
            const string query = "SELECT s.Id,c.Name Client,s.Code,s.Name FROM Shapes s inner join Clients c on c.Id=s.ClientId where ClientId=@ClientId;";
            return Select<Shape>(query, new()
            {
                new("@ClientId", clientId),
            });
        }
    }
}