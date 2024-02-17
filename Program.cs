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

            // skapar en string array som innehåller namn
            string[] names = { "ALMA", "Daniel", "erik", "alex", "aNNA", "Johan","abbi" };


            // skapar en lista för att lagra de filtrerade namnen
            // använder metoden FilterNamesStartingWithLetter för att endast spara
            // namn som börjar på en specifik bokstav som styrs av 'filterLetter'
            List<string> filteredNames = FilterNamesStartingWithLetter(names, filterLetter);

            // sparar den filtrerade listan till en fil baserat på vald bokstav
            SaveListToFile(filteredNames, filterLetter);

            // skriver ut den filtrerade listan till konsolen så man ser att det fungerar
            Console.WriteLine($"Namn som börjar på '{filterLetter}':");
            foreach (string name in filteredNames)
            {
                Console.WriteLine(name);
            }
        }



        // Metod som tar string array som input och returnerar en sorterad lista med element (namn) som börjar på given bokstav
        static List<string> FilterNamesStartingWithLetter(string[] inputNames, char letter)
        {
            // skapar en tom string lista för att lagra filtrerade namn
            List<string> filteredList = new List<string>();

            // går igenom alla namn och lägger till dem i listan OM dem uppnår kraven (börjar med bokstaven A i detta fall)
            // oberoende av stor eller liten bokstav tack vare StringComparison.OrdinalIgnoreCase
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
            
            // definierar sökvägen där filen kommer att sparas, baserad på applikationens nuvarande arbetskatalog
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FilteredNames");

            // kontrollerar om mappen inte finns, skapa den om den inte gör det
            Directory.CreateDirectory(directoryPath);

            // 'filePath' = sökvägen till den specifika filen baserad på angiven bokstav
            string filePath = Path.Combine(directoryPath, $"NamesStartingWith{letter}.txt");

            // skriv listan med namn till filen
            File.WriteAllLines(filePath, list);

            // skriver ut vad som har sparats och vart
            Console.WriteLine($"Filtrerade namn som börjar med bokstaven '{letter}' har sparats i filen: {filePath}");
        }
    }
}
