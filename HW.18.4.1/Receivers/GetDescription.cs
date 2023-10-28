using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._18._4._1.Interfaces;
using YoutubeExplode;

namespace HW._18._4._1.Receivers
{
    internal class GetDescription : Ireceiver
    {
        string _url;
        public GetDescription(string url)
        {
            _url = url;
        }
        public async Task Operation()
        {
            var youtube = new YoutubeClient();
            var videoInfo = youtube.Videos.GetAsync(_url).Result;
            var title = videoInfo.Title;
            var duration = videoInfo.Duration.ToString();

            Console.WriteLine($"{title}, продолжительность - {duration}");
            Console.WriteLine();
        }
    }
}
