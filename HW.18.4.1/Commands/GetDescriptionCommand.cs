using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._18._4._1.Interfaces;

namespace HW._18._4._1.Commands
{
    internal class GetDescriptionCommand : Icommand
    {
        Ireceiver getDescription;
        public GetDescriptionCommand(Ireceiver getDescription)
        {
            this.getDescription = getDescription;
        }

        public async Task Run()
        {
            await getDescription.Operation();
        }
    }
}
