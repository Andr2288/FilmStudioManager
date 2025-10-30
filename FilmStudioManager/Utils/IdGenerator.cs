using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Utils
{
    public class IdGenerator
    {

        public static string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}