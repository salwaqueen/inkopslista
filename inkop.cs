using System;
using System.Collections.Generic;

List<string> names = new List<string>();
List<int> prices = new List<int>();

while (true)
{
    Console.WriteLine("\n--- Inköpslista ---");
    if (names.Count == 0)
{
    Console.WriteLine("Inköpslistan är tom.");
}

    long total = 0;

    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {names[i]} - {prices[i]} kr");
        total += prices[i];
    }

    Console.WriteLine($"Totalt: {total} kr");

    Console.WriteLine("\nSkriv ett varunamn för att lägga till.");
    Console.WriteLine("Skriv ett nummer för att ta bort.");
    Console.WriteLine("Skriv avsluta för att avsluta.");
    Console.Write("> ");

    string? input = Console.ReadLine();

    if (input == null)
    {
        break;
    }

    input = input.Trim();

    if (input.ToLower() == "avsluta")
    {
        break;
    }

    if (input == "")
    {
        Console.WriteLine("Du måste skriva något.");
        continue;
    }

    if (int.TryParse(input, out int number))
    {
        if (number >= 1 && number <= names.Count)
        {
            int index = number - 1;

            Console.WriteLine($"{names[index]} har tagits bort.");

            names.RemoveAt(index);
            prices.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Det numret finns inte i listan.");
        }
    }
    else
    {
        Console.Write("Ange pris i hela kronor: ");
        string? priceInput = Console.ReadLine();

        if (int.TryParse(priceInput, out int price))
        {
            names.Add(input);
            prices.Add(price);

            Console.WriteLine($"{input} har lagts till.");
        }
        else
        {
            Console.WriteLine("Ogiltigt pris. Varan lades inte till.");
        }
    }
}