using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Interfaces
{
    interface IDateOperator
    {
        public DateTime[] GetLastDays();

        public DateTime DateParser(string fileName);
    }
}
