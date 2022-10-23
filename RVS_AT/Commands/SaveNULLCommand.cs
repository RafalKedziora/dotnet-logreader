using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVS_AT.Commands
{
    public class SaveNULLCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Console.WriteLine();
        }
    }
}
