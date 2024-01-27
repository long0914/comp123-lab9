namespace Week_03_lab_09_Song_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To test the constructor and the ToString method

            Console.WriteLine(new Song("Baby", "Justin Bieber", 3.35, SongGenre.Pop));

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
        None = 0,
        Blues = 1,
        Country = 2,
        Electronic = 4,
        Folk = 8,
        HipHop = 16,
        Jazz = 32,
        Pop = 64,
        Rock = 128,
        Soul = 256,
        Metal = 512
    }

    public class Song
    {
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public double Length { get; private set; }
        public SongGenre Genre { get; private set; }

        public Song(string title, string artist, double length, SongGenre genre)
        {
            Title = title;
            Artist = artist;
            Length = length;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"{Title} by {Artist}, {Length} mins, Genre: {Genre}";
        }
    }


    public static class Library
    {
        private static List<Song> songs = new List<Song>();

        public static void DisplaySongs()
        {
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public static void DisplaySongs(double longerThan)
        {
            foreach (var song in songs.Where(s => s.Length > longerThan))
            {
                Console.WriteLine(song);
            }
        }

        public static void DisplaySongs(SongGenre genre)
        {
            foreach (var song in songs.Where(s => s.Genre.HasFlag(genre)))
            {
                Console.WriteLine(song);
            }
        }

        public static void DisplaySongs(string artist)
        {
            foreach (var song in songs.Where(s => s.Artist == artist))
            {
                Console.WriteLine(song);
            }
        }

        public static void LoadSongs(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string title;
                while ((title = reader.ReadLine()) != null)
                {
                    var artist = reader.ReadLine();
                    var length = Convert.ToDouble(reader.ReadLine());
                    var genre = (SongGenre)Enum.Parse(typeof(SongGenre), reader.ReadLine());

                    songs.Add(new Song(title, artist, length, genre));
                }
            }
        }
    }
}
