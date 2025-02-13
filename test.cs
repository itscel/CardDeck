using System;
using System.Collections.Generic;

class Program
{
    public enum Suit { Cloves, Diamond, Heart, Spade }
    public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public override string ToString()
        {
            return $"Suit: {Suit}; Rank: {Rank}";
        }
    }

    static List<Card> deck = new List<Card>();

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Card Deck Menu ---");
            Console.WriteLine("1. Create Deck");
            Console.WriteLine("2. Shuffle Deck");
            Console.WriteLine("3. Deal Cards");
            Console.WriteLine("4. Display Deck");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an action (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateDeck();
                    break;
                case "2":
                    ShuffleDeck();
                    break;
                case "3":
                    DealCards();
                    break;
                case "4":
                    DisplayDeck();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid action.");
                    break;
            }
        }
    }

    static void CreateDeck()
    {
        deck.Clear();  

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                deck.Add(new Card { Suit = suit, Rank = rank });
            }
        }

        Console.WriteLine("Deck created with 52 cards.");
    }
    static void ShuffleDeck()
    {
        Random rand = new Random();
        int n = deck.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }

        Console.WriteLine("Deck shuffled.");
    }


    static void DealCards()
    {
        if (deck.Count == 0)
        {
            Console.WriteLine("The deck is empty. Please create a new deck.");
            return;
        }

        Console.Write("How many cards would you like to deal? ");
        int numCards;
        if (int.TryParse(Console.ReadLine(), out numCards) && numCards > 0 && numCards <= deck.Count)
        {
            Console.WriteLine($"\nDealing {numCards} card(s):");
            for (int i = 0; i < numCards; i++)
            {
                Card dealtCard = deck[0];
                deck.RemoveAt(0); 
                Console.WriteLine(dealtCard);
            }
        }
        else
        {
            Console.WriteLine("Invalid number. Please enter a valid number of cards to deal.");
        }
    }

    static void DisplayDeck()
    {
        if (deck.Count == 0)
        {
            Console.WriteLine("The deck is empty. Please create a new deck.");
            return;
        }

        Console.WriteLine("\nCurrent deck:");
        foreach (var card in deck)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine($"\nCards remaining in the deck: {deck.Count}");
    }
}
