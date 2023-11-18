namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportAlbumsInfo(context, 9));

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumInfo = context.Producers
                .Include(producer => producer.Albums)
                    .ThenInclude(album => album.Songs)
                        .ThenInclude(song => song.Writer)
                .FirstOrDefault(p => p.Id == producerId)!
                .Albums.Select(x => new
                {
                    AlbumName = x.Name,
                    x.ReleaseDate,
                    ProducerName = x.Producer?.Name,
                    AlbumSongs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        WriterName = s.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                        .ThenBy(x => x.WriterName),
                    TotalAlbumPrice = x.Price
                }).OrderByDescending(x => x.TotalAlbumPrice).AsEnumerable();

            StringBuilder result = new();

            foreach (var album in albumInfo)
            {
                result
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine("-Songs:");

                int counter = 1;
                foreach (var song in album.AlbumSongs)
                {
                    result
                        .AppendLine($"---#{counter++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.SongPrice:f2}")
                        .AppendLine($"---Writer: {song.WriterName}");
                }
                result
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();
            var span = new TimeSpan(0, 0, duration);
            var songsAboveDuration = context
                .Songs
                .Where(s => s.Duration > span)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .OrderBy(name => name)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            int counter = 1;

            foreach (var s in songsAboveDuration)
            {
                result
                    .AppendLine($"-Song #{counter++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}");

                if (s.PerformerFullName.Any())
                {
                    result.AppendLine(string
                        .Join(Environment.NewLine, s.PerformerFullName
                            .Select(p => $"---Performer: {p}")));
                }

                result
                    .AppendLine($"---AlbumProducer: {s.AlbumProducerName}")
                    .AppendLine($"---Duration: {s.Duration}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
