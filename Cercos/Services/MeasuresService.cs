using System.Linq;
using Cercos.Database;
using Cercos.Model;

namespace Cercos.Services
{
    public class MeasuresService : DatabaseManager
    {
        public Measure GetSingleFromMaterial(int materialId)
        {
            const string query = "SELECT Me.Id,Me.Name FROM Measures Me inner join Materials Ma on Me.Id = Ma.MeasureId where Ma.Id = @MaterialId;";
            return Select<Measure>(query, new()
            {
                new("@MaterialId", materialId),
            }).SingleOrDefault();
        }
    }
}