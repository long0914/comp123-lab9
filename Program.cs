namespace Week_03_lab_09_Song_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To test the constructor and the ToString method

            Console.WriteLine(new Song("Baby", "Justin Bebier", 3.35, SongGenre.Pop));

            // This is first time that you are using the bitwise or. It is used to specify a combination of genres

            Console.WriteLine(new Song("The Promise", "Chris Cornell", 4.26, SongGenre.Country | SongGenre.Rock));

            // Class methods are invoke with the class name
            Library.LoadSongs("Week_03_lab_09_songs4.txt");

            Console.WriteLine("\n\nAll songs");

            Library.DisplaySongs();

            SongGenre genre = SongGenre.Rock;

            Console.WriteLine($"\n\n{genre} songs");

            Library.DisplaySongs(genre);

            string artist = "Bob Dylan";

            Console.WriteLine($"\n\nSongs by {artist}");

            Library.DisplaySongs(artist);

            double length = 5.0;

            Console.WriteLine($"\n\nSongs more than {length}mins");

            Library.DisplaySongs(length);
        }
    }


    [Flags]
    public enum SongGenre
    {
        Unclassified = 0,
        Pop = 0b1,
        Rock = 0b10,
        Blues = 0b100,
        Country = 0b1_000,
        Metal = 0b10_000,
        Soul = 0b100_000
    }

    public class Song
    {
        public string Artist { get; }
        public string Title { get; }
        public double Length { get; }
        public SongGenre Genre { get; }

        public Song(string title, string artist, double length, SongGenre genre)
        {
            Title = title;
            Artist = artist;
            Length = length;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist} ({Genre}) {Length}min";
        }
    }

    public static class Library
    {
        private static List<Song> songs = new List<Song>();

        public static void LoadSongs(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string title;
                while ((title = reader.ReadLine()) != null)
                {
                    string artist = reader.ReadLine();
                    if (artist == null)
                    {
                        continue;
                    }

                    string lengthStr = reader.ReadLine();
                    if (lengthStr == null)
                    {
                        continue;
                    }
                    double length = Convert.ToDouble(lengthStr);

                    string genreStr = reader.ReadLine();
                    if (genreStr == null)
                    {
                        continue;
                    }
                    SongGenre genre = (SongGenre)Enum.Parse(typeof(SongGenre), genreStr);

                    songs.Add(new Song(title, artist, length, genre));
                }
            }
        }

        public static void DisplaySongs()
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public static void DisplaySongs(double longerThan)
        {
            foreach (var song in songs)
            {
                if (song.Length > longerThan)
                {
                    Console.WriteLine(song);
                }
            }
        }

        public static void DisplaySongs(SongGenre genre)
        {
            foreach (var song in songs)
            {
                if (song.Genre.HasFlag(genre))
                {
                    Console.WriteLine(song);
                }
            }
        }

        public static void DisplaySongs(string artist)
        {
            foreach (var song in songs)
            {
                if (song.Artist == artist)
                {
                    Console.WriteLine(song);
                }
            }
        }
    }
}


