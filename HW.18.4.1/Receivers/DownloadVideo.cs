using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW._18._4._1.Interfaces;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace HW._18._4._1.Receivers
{
    internal class DownloadVideo : Ireceiver
    {
        string _url;
        public DownloadVideo(string url)
        {
            _url = url;
        }
        public async Task Operation()
        {
            Console.WriteLine("Введите путь сохранения видеоролика или нажмите Enter для сохранения в c:\\t");
            string path = Console.ReadLine();
            path = String.IsNullOrWhiteSpace(path) ? "c:\\t" : path;

            Console.WriteLine("Скачивание начато");

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(_url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            if (streamInfo != null)
            {
                var fileName = $"{video.Id}.{streamInfo.Container}";
                var filePath = Path.Combine(path, fileName);

                await Console.Out.WriteLineAsync("starting Videos.Streams.DownloadAsync: " + DateTime.Now);
                await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);
                await Console.Out.WriteLineAsync("finished Videos.Streams.DownloadAsync: " + DateTime.Now);

            }
        }
    }
}
