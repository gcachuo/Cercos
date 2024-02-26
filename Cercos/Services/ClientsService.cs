using Cercos.Database;

namespace Cercos.Services
{
    public class ClientsService : DatabaseManager
    {
        public void Insert(string name, string address, string phone, string email)
        {
            const string query = @"INSERT INTO Clients (Name,Address,Phone,Email) VALUES (@Name,@Address,@Phone,@Email)";
            Insert(query, new()
            {
                new("@Name", name),
                new("@Address", address),
                new("@Phone", phone),
                new("@Email", email),
            });
        }
    }
}