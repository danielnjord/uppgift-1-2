using System;
using System.Collections.Generic;
using System.IO;

namespace uppgift_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char filterLetter = 'a'; // Ändra denna bokstav för att se/spara namn som börjar på annan bokstav
            string[] names = { "ALMA", "Daniel", "erik", "alex", "aNNA", "Johan", "abbi" };

            // Använder NameFilter-klassen för att filtrera namn baserat på given bokstav
            List<string> filteredNames = NameFilter.FilterNamesStartingWithLetter(names, filterLetter);

            // Använder FileSaver-klassen för att spara den filtrerade listan till en fil
            FileSaver.SaveListToFile(filteredNames, filterLetter);

            // Skriver ut den filtrerade listan till konsolen så att man ser att det fungerar
            Console.WriteLine($"Namn som börjar på '{filterLetter}':");
            foreach (string name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }
    }

    // Klassen som innehåller logiken för att filtrera namn baserat på en given bokstav
    public static class NameFilter
    {
        public static List<string> FilterNamesStartingWithLetter(string[] inputNames, char letter)
        {
            List<string> filteredList = new List<string>();

            // Går igenom varje namn i listan och lägger till dem i den filtrerade listan om de börjar på den givna bokstaven
            foreach (string name in inputNames)
            {
                if (name.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    filteredList.Add(name);
                }
            }
            return filteredList;
        }
    }

    // Klassen som innehåller logiken för att spara en lista med namn till en fil baserat på en given bokstav
    public static class FileSaver
    {
        public static void SaveListToFile(List<string> list, char letter)
        {
            // Definierar sökvägen där filen kommer att sparas, baserad på applikationens nuvarande arbetskatalog
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilteredNames");
            Directory.CreateDirectory(directoryPath);

            // 'filePath' = sökvägen till den specifika filen baserad på angiven bokstav
            string filePath = Path.Combine(directoryPath, $"NamesStartingWith{letter}.txt");

            // Skriver listan med namn till filen
            File.WriteAllLines(filePath, list);

            // Skriver ut vad som har sparats och var
            Console.WriteLine($"Filtrerade namn som börjar med bokstaven '{letter}' har sparats i filen: {filePath}");
        }
    }
}
