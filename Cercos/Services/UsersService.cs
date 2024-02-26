using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Cercos.Database;
using Cercos.Model;
using Cercos.Tools;

namespace Cercos.Services
{
    public class UsersService
    {
        private static readonly DatabaseManager DatabaseManager = new();

        public static void Insert(string fullname, string passwordHashed)
        {
            const string query = @"INSERT INTO Users (FullName, Password) VALUES (@FullName, @Password)";

            DatabaseManager.Insert(query, new()
            {
                new("@FullName", fullname),
                new("@Password", passwordHashed),
            });
        }

        public static bool CheckDuplicates(string password)
        {
            const string query = "SELECT Password FROM Users;";
            var users = DatabaseManager.Select<User>(query);

            return users.Any(user => PasswordHasher.VerifyPassword(password, user.Password));
        }
    }
}