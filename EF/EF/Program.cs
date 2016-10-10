using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        [Table("Artist")]
        public class Artist
        {
            public int ArtistId { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Album> Albums { get; set; }
        }

        public class Album
        {
            public int AlbumId { get; set; }
            public string Title { get; set; }
            public virtual Artist Artist { get; set; }
            public virtual ICollection<Track> Tracks { get; set; }
        }

        public class Track
        {
            public int TrackId { get; set; }
            public string Name { get; set; }
            public virtual Album Album { get; set; }
        }

        public class Chinook : DbContext
        {
            public Chinook() : base("name=Chinook")
            {

            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                Database.SetInitializer<Chinook>(null);
                base.OnModelCreating(modelBuilder);
            }

            public DbSet<Artist> Artist { get; set; }
            public DbSet<Album> Album { get; set; }
            public DbSet<Track> Track { get; set; }
        }

        static void Main(string[] args)
        {
            using (Chinook db = new Chinook())
            {
                foreach (var artist in db.Artist)
                {
                    Console.WriteLine(artist.Name);
                }

                Console.ReadLine();
            }
        }
    }
}
