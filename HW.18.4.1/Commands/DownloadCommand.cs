using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._18._4._1.Interfaces;

namespace HW._18._4._1.Commands
{
    internal class DownloadCommand : Icommand
    {
        Ireceiver download;

        public DownloadCommand(Ireceiver download)
        {
            this.download = download;
        }

        public async Task Run()
        {
            await download.Operation();
            await Console.Out.WriteLineAsync("Скачивание завершено");
        }
    }
}
