using System.Collections;
using Cercos.Database;
using Cercos.Model;

namespace Cercos.Services
{
    public class ColorsService : DatabaseManager
    {
        public IEnumerable GetAll()
        {
            const string query = "SELECT Id, Name FROM Colors order by Id;";
            return Select<Color>(query);
        }
    }
}