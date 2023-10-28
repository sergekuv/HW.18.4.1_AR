using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._18._4._1.Interfaces;

namespace HW._18._4._1
{
    internal class User
    {
        Icommand _command;

        public void SetCommand(Icommand command)
        { 
            this._command = command; 
        }

        public async Task  RunCommand()
        {
            await _command.Run();
        }

    }
}
