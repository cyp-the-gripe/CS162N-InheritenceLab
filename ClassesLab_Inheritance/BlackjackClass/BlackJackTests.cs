using System;

namespace CardClasses
{
    internal class BlackJackTests
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Hand hand = new Hand(deck, 5);

            Console.WriteLine("Initial Hand:");
            Console.WriteLine(hand);

            Console.WriteLine("Number of Cards: " + hand.NumCards);

            Card newCard = new Card(1, 4);

            hand.Add(newCard);

            Console.WriteLine("After Adding Ace of Spades:");
            Console.WriteLine(hand);

            Console.WriteLine("Has Ace of Spades: " + hand.HasCard(newCard));
            Console.WriteLine("Has Any Ace: " + hand.HasCard(1));
            Console.WriteLine("Has Ace of Spades by value/suit: " + hand.HasCard(1, 4));

            Console.WriteLine("Index of Ace of Spades: " + hand.IndexOf(newCard));
            Console.WriteLine("Index of Any Ace: " + hand.IndexOf(1));
            Console.WriteLine("Index of Ace of Spades by value/suit: " + hand.IndexOf(1, 4));

            Card removed = hand.Discard(0);

            Console.WriteLine("Discarded Card: " + removed);

            Console.WriteLine("Hand After Discard:");
            Console.WriteLine(hand);

            Console.WriteLine("First Card in Hand: " + hand.GetCard(0));

            Console.ReadLine();
        }
    }
}