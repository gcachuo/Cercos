using System.Collections;
using Cercos.Database;
using Cercos.Model;

namespace Cercos.Services
{
    public class MaterialsService : DatabaseManager
    {
        public IEnumerable GetAll()
        {
            const string query = "SELECT Id, Name FROM Materials order by Id;";
            return Select<Material>(query);
        }
    }
}