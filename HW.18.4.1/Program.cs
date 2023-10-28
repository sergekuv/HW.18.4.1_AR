using HW._18._4._1.Commands;
using HW._18._4._1.Interfaces;
using HW._18._4._1.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace HW._18._4._1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Введите url видеоролика или нажмите Enter");
            string url = Console.ReadLine();
            url = String.IsNullOrWhiteSpace(url) ? "https://www.youtube.com/watch?v=A7MNA-qMOMM" : url;


            User user = new User();
            Ireceiver getDescription = new GetDescription(url);
            user.SetCommand(new GetDescriptionCommand(getDescription));
            await user.RunCommand();

            Ireceiver download = new DownloadVideo(url);
            user.SetCommand(new DownloadCommand(download));
            await user.RunCommand();
            Console.ReadKey();
        }
    }
}