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

            // Skapar en string array som innehåller följande namn samt skapar en lista som använder sig utav
            // metoden FilterNamesStartingWithLetter för att endast spara namnen som börjar på en specifik bokstav
            // den filtrerade listan sparas sedan till en fil med ett namn som börjar på filterLetter.
            string[] names = { "ALMA", "Daniel", "erik", "alex", "aNNA", "Johan","abbi" };
            List<string> filteredNames = FilterNamesStartingWithLetter(names, filterLetter);

            // Skapa en katalog för bokstaven filterLetter och spara den filtrerade listan
            SaveListToFile(filteredNames, filterLetter);

            // Skriver ut den filtrerade listan till konsolen så man ser att det fungerar
            Console.WriteLine($"Namn som börjar på '{filterLetter}':");
            foreach (string name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }


        // Metod som tar string array som input och returnerar en sorterad lista med element (namn) som börjar på given bokstav
        static List<string> FilterNamesStartingWithLetter(string[] inputNames, char letter)
        {
            // skapar en tom lista för att lagra filtrerade namn
            List<string> filteredList = new List<string>();

            // går igenom alla namn och lägger till dem i listan om dem uppnår kraven (börjar med bokstaven A i detta fall)
            foreach (string name in inputNames)
            {
                if (name.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    filteredList.Add(name);
                }
            }
            return filteredList;
        }



        // metod för att spara en lista med namn till en fil med en specifik bokstav
        static void SaveListToFile(List<string> list, char letter)
        {
            // sparar namnen i en txt fil på denna plats
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilteredNames");


            Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, $"NamesStartingWith{letter}.txt");

            File.WriteAllLines(filePath, list);

            Console.WriteLine($"Filtrerade namn som börjar med bokstaven '{letter}' har sparats i filen: {filePath}");

        }
    }
}
