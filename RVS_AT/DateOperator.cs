using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RVS_AT.Interfaces;

namespace RVS_AT
{
    class DateOperator : IDateOperator
    {
        public DateTime DateParser(string fileName)
        {
            DateTime parsedDay;
            try
            {
                parsedDay = DateTime.Parse(fileName.Remove(10));
            }
            catch (Exception e)
            {
                if (fileName == "latest.log")
                {
                    parsedDay = DateTime.Now.Date;
                }
                else
                {
                    parsedDay = DateTime.MinValue.Date;
                    Console.WriteLine(e.Message);
                }
            }

            return parsedDay;
        }

        public DateTime[] GetLastDays()
        { 
            var lastDays = Enumerable.Range(0, 2).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();
            return lastDays;
        }
    }
}
