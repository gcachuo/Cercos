using System.Collections.Generic;
using System.Linq;

namespace Cercos.Tools
{
    public class Validation
    {
        public static bool ValidateFields(IEnumerable<string> fields)
        {
            return fields.All(field => !string.IsNullOrWhiteSpace(field));
        }
    }
}