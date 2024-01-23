using System;
using System.Collections.Generic;
using System.IO;



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
                double length = Convert.ToDouble(reader.ReadLine());
                SongGenre genre = (SongGenre)Enum.Parse(typeof(SongGenre), reader.ReadLine());
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
