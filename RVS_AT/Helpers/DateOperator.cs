using System;
using System.Linq;
using System.Threading.Tasks;

namespace RVS_AT
{
    class DateOperator
    {
        public async Task<DateTime> DateParser(string fileName)
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
            var result = await Task.FromResult(parsedDay);

            return result;
        }

        public async Task<DateTime[]> GetLastDays()
        { 
            var lastDays = Enumerable.Range(0, 4).Select(i => DateTime.Now.Date.AddDays(-i)).ToArray();
            var result = await Task.FromResult(lastDays);
            return result;
        }
    }
}
