using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace test.Data
{
    public interface IHomeDataService
    {
        double WaardeInvullen(double waarde1, double waarde2, string operation);

        
    }
}
