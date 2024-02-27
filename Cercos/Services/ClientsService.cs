using System.Collections;
using System.Collections.Generic;
using Cercos.Database;
using Cercos.Model;

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

        public List<Client> GetAllClients()
        {
            const string query = "SELECT * FROM Clients;";
            return Select<Client>(query);
        }
    }
}