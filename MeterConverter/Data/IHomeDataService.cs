using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MeterConverter.Enums;

namespace MeterConverter.Data
{
    public interface IHomeDataService
    {
        double WaardeInvullen(double waarde1, double waarde2, Operator operation);

        
    }
}
