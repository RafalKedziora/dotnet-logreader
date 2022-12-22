using System;

namespace AvaloniaLogReader
{
    public static class DateOperator
    {
        public static DateTime DateParser(string fileName)
        {
            DateTime parsedDay;
            try
            {
                parsedDay = DateTime.Parse(fileName);
            }
            catch (Exception e)
            {
                if (fileName == "latest")
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
    }
}
